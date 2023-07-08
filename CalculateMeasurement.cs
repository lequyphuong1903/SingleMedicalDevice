using System;
using System.Linq;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    internal class CalculateMeasurement
    {
        private int LogCount = 0;
        private int[] IRBuf = new int[100];
        private int[] IRBuf2 = new int[100];
        private int[] RedBuf = new int[100];
        private int ir_mean = 0;
        private int threshold = 0;
        private int[] an_ir_valley_locs = new int[15];
        private int[] an_ratio = new int[5];
        private int n_npks;
        private int n_peak_interval_sum;
        public int pn_heart_rate { get; set; }  // HR value
        public List<int> hrList = new List<int>();
        public List<int> spo2List = new List<int>();
        private int pn_heart_rate_previous;     // // temp SPO2 value
        public int pn_spo2 { get; set; }        // SPO2 value
        private int pn_spo2_previous;
        private int n_exact_ir_valley_locs_count;
        private int n_ratio_average;
        private int n_i_ratio_count;
        private int n_y_dc_max;
        private int n_x_dc_max;
        private int n_x_dc_max_idx;
        private int n_y_dc_max_idx;
        private int n_y_ac;
        private int n_x_ac;
        private int n_nume;
        private int n_denom;
        private int n_middle_idx;
        private int n_spo2_calc;
        private int[] uch_spo2_table ={ 95, 95, 95, 96, 96, 96, 97, 97, 97, 97, 97, 98, 98, 98, 98, 98, 99, 99, 99, 99,
              99, 99, 99, 99, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100,
              100, 100, 100, 100, 99, 99, 99, 99, 99, 99, 99, 99, 98, 98, 98, 98, 98, 98, 97, 97,
              97, 97, 96, 96, 96, 96, 95, 95, 95, 94, 94, 94, 93, 93, 93, 92, 92, 92, 91, 91,
              90, 90, 89, 89, 89, 88, 88, 87, 87, 86, 86, 85, 85, 84, 84, 83, 82, 82, 81, 81,
              80, 80, 79, 78, 78, 77, 76, 76, 75, 74, 74, 73, 72, 72, 71, 70, 69, 69, 68, 67,
              66, 66, 65, 64, 63, 62, 62, 61, 60, 59, 58, 57, 56, 56, 55, 54, 53, 52, 51, 50,
              49, 48, 47, 46, 45, 44, 43, 42, 41, 40, 39, 38, 37, 36, 35, 34, 33, 31, 30, 29,
              28, 27, 26, 25, 23, 22, 21, 20, 19, 17, 16, 15, 14, 12, 11, 10, 9, 7, 6, 5,
              3, 2, 1 };
        public void LogBuff(UInt16[] value2, UInt16[] value3)
        {

            for (int k = 0; k < value2.Length; k++)
            {
                IRBuf[LogCount] = value3[k];
                IRBuf2[LogCount] = value3[k];
                RedBuf[LogCount] = value2[k];
                LogCount++;
            }
            if (LogCount == 100)
            {
                LOLMEMAY();
                LogCount = 0;
            }
        }
        private void LOLMEMAY()
        {
            ir_mean = 0;
            for (int k = 0; k < IRBuf.Length; k++)  // Get ir_mean_raw
            {
                ir_mean += IRBuf[k];
            }
            ir_mean = ir_mean / IRBuf.Length;

            for (int k = 0; k < IRBuf.Length; k++)  // Invert and calib
            {
                IRBuf[k] = (-1) * (IRBuf[k] - ir_mean);
            }
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 96; k++)    // Moving average
                {
                    IRBuf[k] = (IRBuf[k] + IRBuf[k + 1] + IRBuf[k + 2] + IRBuf[k + 3]) / (int)4;
                }
            }    
            
            threshold = 0;
            for (int k = 0; k < IRBuf.Length; k++)
            {
                threshold += IRBuf[k];
            }
            threshold = threshold / IRBuf.Length;
            if (threshold < 20)
                threshold = 20;     // Min allow
            if (threshold > 20)
                threshold = 20;     // Max allow

            for (int k = 0; k < 15; k++)    // Reset IR
            {
                an_ir_valley_locs[k] = 0;
            }
            for (int k = 0; k < 1; k++)
            {
                maxim_find_peaks(an_ir_valley_locs, IRBuf, 100, threshold, 4, 15);
            }    
            

            n_peak_interval_sum = 0;
            if (n_npks >= 2)
            {
                for (int k = 1; k < n_npks; k++)
                {
                    n_peak_interval_sum += (an_ir_valley_locs[k] - an_ir_valley_locs[k - 1]);
                }
                
                n_peak_interval_sum = n_peak_interval_sum / (n_npks - 1);
                pn_heart_rate_previous = ((25 * 30) / n_peak_interval_sum);
                if (pn_heart_rate_previous > 150)
                    pn_heart_rate_previous = 150;
                if (pn_heart_rate_previous < 50)
                    pn_heart_rate_previous = 50;
                hrList.Add(pn_heart_rate_previous);
                //pn_heart_rate = n_npks;
                pn_heart_rate = (int)hrList.Average();
            }
            else
            {
                pn_heart_rate = -999; // unable to calculate because # of peaks are too small
            }

            //// Cal SPO2

            // find precise min near an_ir_valley_locs
            n_exact_ir_valley_locs_count = n_npks;

            n_ratio_average = 0;
            n_i_ratio_count = 0;

            // Reset ratio
            for (int k = 0; k < 5; k++)
            {
                an_ratio[k] = 0;
            }
            for (int k = 0; k < n_exact_ir_valley_locs_count; k++)
            {
                if (an_ir_valley_locs[k] > 100)
                {
                    pn_spo2 = -999; // do not use SPO2 since valley loc is out of range
                    return;
                }
            }
            // find max between two valley locations 
            // and use an_ratio betwen AC compoent of Ir & Red and DC compoent of Ir & Red for SPO2 
            for (int k = 0; k < n_exact_ir_valley_locs_count - 1; k++)
            {
                n_y_dc_max = -16777216;
                n_x_dc_max = -16777216;
                if (an_ir_valley_locs[k + 1] - an_ir_valley_locs[k] > 3)
                {
                    for (int i = an_ir_valley_locs[k]; i < an_ir_valley_locs[k + 1]; i++)
                    {
                        if (IRBuf2[i] > n_x_dc_max)
                        {
                            n_x_dc_max = IRBuf2[i];
                            n_x_dc_max_idx = i;
                        }
                        if (RedBuf[i] > n_y_dc_max)
                        {
                            n_y_dc_max = RedBuf[i];
                            n_y_dc_max_idx = i;
                        }
                    }
                    n_y_ac = (RedBuf[an_ir_valley_locs[k + 1]] - RedBuf[an_ir_valley_locs[k]]) * (n_y_dc_max_idx - an_ir_valley_locs[k]); //red
                    n_y_ac = RedBuf[an_ir_valley_locs[k]] + n_y_ac / (an_ir_valley_locs[k + 1] - an_ir_valley_locs[k]);
                    n_y_ac = RedBuf[n_y_dc_max_idx] - n_y_ac;    // subracting linear DC compoenents from raw 
                    n_x_ac = (IRBuf2[an_ir_valley_locs[k + 1]] - IRBuf2[an_ir_valley_locs[k]]) * (n_x_dc_max_idx - an_ir_valley_locs[k]); // ir
                    n_x_ac = IRBuf2[an_ir_valley_locs[k]] + n_x_ac / (an_ir_valley_locs[k + 1] - an_ir_valley_locs[k]);
                    n_x_ac = IRBuf2[n_y_dc_max_idx] - n_x_ac;      // subracting linear DC compoenents from raw 
                    n_nume = (n_y_ac * n_x_dc_max) >> 7; //prepare X100 to preserve floating value
                    n_denom = (n_x_ac * n_y_dc_max) >> 7;
                    if (n_denom > 0 && n_i_ratio_count < 5 && n_nume != 0)
                    {
                        an_ratio[n_i_ratio_count] = (n_nume * 100) / n_denom; //formular is ( n_y_ac *n_x_dc_max) / ( n_x_ac *n_y_dc_max) ;
                        n_i_ratio_count++;
                    }
                }
            }
            // choose median value since PPG signal may varies from beat to beat
            maxim_sort_ascend(an_ratio, n_i_ratio_count);
            n_middle_idx = n_i_ratio_count / 2;

            if (n_middle_idx > 1)
                n_ratio_average = (an_ratio[n_middle_idx - 1] + an_ratio[n_middle_idx]) / 2; // use median
            else
                n_ratio_average = an_ratio[n_middle_idx];

            if (n_ratio_average > 2 && n_ratio_average < 183)
            {
                n_spo2_calc = uch_spo2_table[n_ratio_average];
                pn_spo2_previous = n_spo2_calc;
                if (pn_spo2_previous > 85)
                {
                    spo2List.Add(pn_spo2_previous);
                    pn_spo2 = (int)spo2List.Average();
                }                          
            //  float_SPO2 =  -45.060*n_ratio_average* n_ratio_average/10000 + 30.354 *n_ratio_average/100 + 94.845 ;
            // for comparison with table
            }
            else
            {
                pn_spo2 = -999; // do not use SPO2 since signal an_ratio is out of range
            }
        }
        private void maxim_find_peaks(int[] pn_locs, int[] pn_x, int n_size, int n_min_height, int n_min_distance, int n_max_num)
        {
            maxim_peaks_above_min_height(pn_locs, pn_x, n_size, n_min_height);
            maxim_remove_close_peaks(pn_locs, pn_x, n_min_distance);
            n_npks = Math.Min(n_npks, n_max_num);
        }
        private void maxim_peaks_above_min_height(int[] pn_locs, int[] pn_x, int n_size, int n_min_height)
        {
            int i, n_width;
            n_npks = 0;
            i = 1;
            while (i < n_size - 1)
            {
                if (pn_x[i] > n_min_height && pn_x[i] > pn_x[i - 1])
                {      // find left edge of potential peaks
                    n_width = 1;
                    while (i + n_width < n_size && pn_x[i] == pn_x[i + n_width])  // find flat peaks
                        n_width++;
                    int j = i + n_width;
                    if (j > 14)
                        j = 14;
                    if (pn_x[i] > pn_x[j] && (n_npks) < 15)
                    {      // find right edge of peaks
                        pn_locs[(n_npks)++] = i;
                        // for flat peaks, peak location is left edge
                        i += n_width + 1;
                    }
                    else
                        i += n_width;
                }
                else
                    i++;
            }
        }
        private void maxim_remove_close_peaks(int[] pn_locs, int[] pn_x, int n_min_distance)
        {

            int i, j, n_old_npks, n_dist;

            /* Order peaks from large to small */
            maxim_sort_indices_descend(pn_x, pn_locs, n_npks);

            for (i = -1; i < n_npks; i++)
            {
                n_old_npks = n_npks;
                n_npks = i + 1;
                for (j = i + 1; j < n_old_npks; j++)
                {
                    n_dist = pn_locs[j] - (i == -1 ? -1 : pn_locs[i]); // lag-zero peak of autocorr is at index -1
                    if (n_dist > n_min_distance || n_dist < -n_min_distance)
                        pn_locs[(n_npks)++] = pn_locs[j];
                }
            }

            // Resort indices int32_to ascending order
            maxim_sort_ascend(pn_locs, n_npks);

        }
        private void maxim_sort_indices_descend(int[] pn_x, int[] pn_indx, int n_size)
        {
            int i, j, n_temp;
            for (i = 1; i < n_size; i++)
            {
                n_temp = pn_indx[i];
                for (j = i; j > 0 && pn_x[n_temp] > pn_x[pn_indx[j - 1]]; j--)
                    pn_indx[j] = pn_indx[j - 1];
                pn_indx[j] = n_temp;
            }
        }
        private void maxim_sort_ascend(int[] pn_x, int n_size)
        {
            int i, j, n_temp;
            for (i = 1; i < n_size; i++)
            {
                n_temp = pn_x[i];
                for (j = i; j > 0 && n_temp < pn_x[j - 1]; j--)
                    pn_x[j] = pn_x[j - 1];
                pn_x[j] = n_temp;
            }
        }
    }
}
