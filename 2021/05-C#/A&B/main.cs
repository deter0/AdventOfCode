using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Program
{
    class V2
    {
        public int x;
        public int y;
    }
    class Line
    {
        public V2 From = new V2();
        public V2 To = new V2();
    }
    class Program
    {
        private static MatchCollection getMatches(string text, string expression)
        {
            MatchCollection mc = Regex.Matches(text, expression);
            return mc;
        }

        static void Main(string[] args)
        {
            List<Line> Lines = new List<Line>();
            MatchCollection mc = getMatches(Input, @"([0-9]+),([0-9]+) -> ([0-9]+),([0-9]+)");
            for (int i = 0; i < mc.Count; i++)
            {
                Line l = new Line();
                l.From.x = int.Parse(mc[i].Groups[1].Value);
                l.From.y = int.Parse(mc[i].Groups[2].Value);
                l.To.x = int.Parse(mc[i].Groups[3].Value);
                l.To.y = int.Parse(mc[i].Groups[4].Value);
                Lines.Add(l);
            }
            // Find greatest x and y in Lines
            int GreatestX = 0;
            int GreatestY = 0;
            foreach (Line Line in Lines)
            {
                GreatestX = Math.Max(Math.Max(Line.To.x, Line.From.x), GreatestX);
                GreatestY = Math.Max(Math.Max(Line.To.y, Line.From.y), GreatestY);
            }
            Console.WriteLine("Num Lines: {0}", Lines.Count);
            Console.WriteLine("GreatestX: {0}", GreatestX);
            Console.WriteLine("GreatestY: {0}", GreatestY);
            // Create an 2 dimensional array to greatest x and y
            int[,] Grid = new int[GreatestX + 1, GreatestY + 1];
            // Fill the array the lines
            Console.WriteLine("Grid size: {0}", Grid.Length);
            foreach (Line Line in Lines)
            {
                int x0 = Line.From.x;
                int y0 = Line.From.y;
                int x1 = Line.To.x;
                int y1 = Line.To.y;

                int dx = Math.Abs(x1 - x0); // 9
                float sx = (float)x0 < x1 ? 1 : -1; // 1
                int dy = -Math.Abs(y1 - y0); // 9
                float sy = (float)y0 < y1 ? 1 : -1; // 1
                float err = (float)dx + dy; // 18
                while (true)
                {
                    Grid[x0, y0]++; // 0, 0
                    if (x0 == x1 && y0 == y1) // false
                        break;
                    float e2 = err * 2; // 36
                    if (e2 >= dy) // (9) true
                    {
                        err += dy;
                        x0 += (int)sx;
                    }
                    if (e2 <= dx)
                    {
                        err += dx;
                        y0 += (int)sy;
                    }
                }
            }
            int Collisions = 0;
            // Print the grid
            for (int y = 0; y < GreatestY + 1; y++)
            {
                for (int x = 0; x < GreatestX + 1; x++)
                {
                    if (Grid[x, y] >= 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (Grid[x, y] >= 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (Grid[x, y] >= 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (Grid[x, y] > 0)
                    {
                        Console.Write(Grid[x, y] + " ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    if (Grid[x, y] >= 2)
                    {
                        Collisions++;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(Collisions);
        }
        private static string Input =
            @"491,392 -> 34,392
337,52 -> 485,52
256,605 -> 256,959
889,142 -> 153,878
189,59 -> 512,382
399,193 -> 598,193
578,370 -> 795,153
79,450 -> 569,450
565,444 -> 270,149
39,28 -> 39,846
114,353 -> 114,383
356,61 -> 356,327
140,132 -> 515,132
361,848 -> 361,527
466,257 -> 466,784
818,397 -> 818,14
693,554 -> 693,984
171,290 -> 171,655
989,889 -> 170,70
527,855 -> 527,549
209,355 -> 486,355
800,430 -> 291,939
980,38 -> 31,987
964,559 -> 964,799
491,612 -> 930,173
57,977 -> 958,76
149,465 -> 349,465
512,624 -> 629,507
460,943 -> 460,441
988,29 -> 988,968
104,337 -> 441,337
939,48 -> 939,546
941,904 -> 498,461
850,972 -> 649,771
840,901 -> 23,84
231,790 -> 231,873
230,668 -> 840,58
410,922 -> 435,897
341,337 -> 341,406
264,752 -> 258,752
457,969 -> 457,757
465,42 -> 465,350
748,783 -> 502,783
461,930 -> 461,142
392,265 -> 215,265
417,805 -> 417,231
825,870 -> 60,105
524,167 -> 703,346
963,829 -> 308,174
730,361 -> 730,252
61,373 -> 61,593
873,893 -> 132,152
820,719 -> 417,719
142,238 -> 212,168
142,653 -> 676,119
392,955 -> 392,453
368,385 -> 414,385
464,762 -> 592,762
542,168 -> 542,789
622,693 -> 166,237
477,290 -> 792,290
731,56 -> 731,677
516,77 -> 326,77
595,973 -> 779,973
68,487 -> 128,487
389,738 -> 762,738
721,13 -> 827,119
797,625 -> 347,625
75,67 -> 75,458
931,142 -> 219,854
422,835 -> 980,835
278,565 -> 753,565
225,970 -> 806,389
791,725 -> 691,725
924,975 -> 18,69
326,763 -> 969,120
663,895 -> 663,559
940,965 -> 142,167
146,425 -> 791,425
832,968 -> 272,408
494,804 -> 694,804
23,25 -> 900,902
621,163 -> 894,163
587,605 -> 587,716
41,931 -> 383,589
888,530 -> 341,530
292,801 -> 292,567
537,213 -> 245,213
513,84 -> 527,84
623,516 -> 623,128
549,729 -> 509,729
576,232 -> 869,232
513,847 -> 433,847
536,612 -> 434,612
608,377 -> 33,952
137,762 -> 424,475
329,286 -> 584,541
493,296 -> 493,316
160,343 -> 189,343
477,929 -> 976,430
695,607 -> 557,607
745,322 -> 28,322
777,73 -> 76,774
163,723 -> 163,816
30,549 -> 63,516
163,914 -> 898,179
603,823 -> 603,78
498,616 -> 886,228
229,591 -> 341,591
742,841 -> 343,841
720,808 -> 934,808
985,48 -> 48,985
368,859 -> 178,859
506,30 -> 144,30
19,110 -> 19,750
293,689 -> 293,294
13,462 -> 980,462
536,963 -> 346,773
836,471 -> 462,471
506,952 -> 489,952
830,15 -> 461,15
392,378 -> 237,378
295,48 -> 295,825
264,679 -> 264,602
487,582 -> 487,116
832,677 -> 788,677
469,770 -> 211,512
400,773 -> 394,773
262,836 -> 262,454
51,17 -> 969,935
483,525 -> 838,880
71,124 -> 164,31
103,226 -> 912,226
785,169 -> 785,454
858,825 -> 176,143
248,960 -> 427,781
255,37 -> 767,37
832,149 -> 506,149
256,246 -> 86,246
447,448 -> 765,448
654,159 -> 654,158
120,500 -> 120,341
200,19 -> 839,658
451,251 -> 763,563
931,75 -> 931,312
69,404 -> 311,646
31,678 -> 31,231
410,307 -> 410,236
988,976 -> 387,375
654,402 -> 738,486
30,942 -> 942,30
115,652 -> 98,669
405,764 -> 375,734
88,759 -> 125,759
636,835 -> 722,835
300,60 -> 126,60
159,225 -> 159,319
934,188 -> 934,74
46,822 -> 708,160
605,612 -> 605,463
200,281 -> 536,617
392,11 -> 79,324
917,126 -> 258,785
803,143 -> 803,180
116,556 -> 651,556
922,222 -> 468,676
266,782 -> 896,782
733,448 -> 764,448
915,75 -> 305,685
150,243 -> 842,243
485,641 -> 963,641
965,206 -> 965,275
78,868 -> 748,198
37,947 -> 859,947
429,289 -> 429,48
378,261 -> 378,624
768,494 -> 768,782
702,566 -> 113,566
290,148 -> 913,771
806,931 -> 849,931
725,970 -> 299,970
38,565 -> 740,565
262,730 -> 973,730
826,376 -> 826,97
318,576 -> 318,227
159,868 -> 448,868
344,256 -> 344,615
824,188 -> 588,424
505,843 -> 897,843
293,348 -> 293,488
433,833 -> 165,565
56,471 -> 169,471
77,896 -> 914,59
405,904 -> 405,174
274,364 -> 274,88
785,704 -> 538,704
877,389 -> 681,389
790,936 -> 327,936
89,143 -> 755,809
721,450 -> 721,406
253,664 -> 811,664
881,143 -> 97,927
205,738 -> 645,738
869,951 -> 282,364
374,697 -> 374,592
251,989 -> 251,977
521,187 -> 885,187
536,401 -> 536,38
636,840 -> 636,873
695,333 -> 52,976
790,757 -> 790,358
314,765 -> 882,765
880,439 -> 127,439
266,848 -> 810,304
802,419 -> 802,936
554,67 -> 554,956
311,379 -> 685,753
183,544 -> 305,544
857,341 -> 407,791
306,559 -> 727,980
184,477 -> 509,152
934,174 -> 934,154
28,12 -> 28,968
418,984 -> 112,678
788,89 -> 837,89
229,425 -> 192,462
714,701 -> 424,411
198,313 -> 156,355
142,742 -> 215,742
15,639 -> 15,787
573,396 -> 462,396
954,977 -> 76,99
645,448 -> 652,448
958,822 -> 376,240
47,359 -> 212,194
524,366 -> 524,916
100,977 -> 501,576
932,148 -> 115,965
854,120 -> 421,553
318,630 -> 318,964
196,31 -> 874,709
812,826 -> 812,679
111,890 -> 897,104
46,35 -> 972,35
40,842 -> 40,835
390,510 -> 98,510
832,57 -> 124,765
422,331 -> 422,44
696,837 -> 696,555
849,571 -> 849,679
598,143 -> 598,261
670,745 -> 670,757
660,390 -> 660,912
960,578 -> 960,253
123,343 -> 123,28
643,199 -> 969,199
66,642 -> 669,39
776,30 -> 776,173
595,951 -> 84,951
908,183 -> 724,367
330,332 -> 330,455
954,955 -> 188,955
981,269 -> 90,269
235,579 -> 513,579
217,25 -> 217,990
811,810 -> 811,405
245,255 -> 367,255
860,225 -> 860,100
753,626 -> 697,626
755,404 -> 836,404
733,476 -> 336,476
562,172 -> 964,172
339,989 -> 749,989
167,581 -> 167,611
217,475 -> 217,747
103,598 -> 431,270
11,989 -> 989,11
925,90 -> 46,969
26,963 -> 935,54
40,925 -> 40,816
67,942 -> 984,25
933,652 -> 933,242
942,292 -> 942,138
889,909 -> 180,200
604,770 -> 237,770
30,627 -> 973,627
750,777 -> 750,645
254,797 -> 254,169
939,167 -> 347,759
889,682 -> 394,682
788,338 -> 388,338
757,252 -> 169,252
806,131 -> 699,131
562,270 -> 562,481
950,349 -> 459,840
219,915 -> 932,202
977,505 -> 977,708
915,559 -> 915,125
366,397 -> 366,717
54,723 -> 433,723
570,842 -> 236,508
513,365 -> 513,80
569,523 -> 569,266
278,764 -> 278,178
136,136 -> 84,84
787,108 -> 787,809
461,388 -> 855,782
64,898 -> 848,114
628,71 -> 178,521
842,66 -> 842,699
293,68 -> 742,68
960,102 -> 358,704
834,669 -> 27,669
11,43 -> 374,406
399,803 -> 340,803
564,211 -> 20,755
370,841 -> 370,321
518,590 -> 518,255
470,150 -> 470,850
769,182 -> 234,717
97,787 -> 97,382
36,31 -> 982,977
831,467 -> 471,827
253,836 -> 547,836
957,681 -> 957,919
768,831 -> 768,275
98,36 -> 955,893
283,413 -> 840,413
21,870 -> 20,870
979,507 -> 979,37
339,757 -> 210,757
388,594 -> 801,594
867,939 -> 91,163
755,864 -> 755,501
856,177 -> 736,57
74,365 -> 376,63
386,451 -> 815,22
389,883 -> 679,593
116,216 -> 157,175
693,960 -> 693,454
704,962 -> 306,962
613,442 -> 867,442
578,13 -> 578,855
417,683 -> 118,683
127,161 -> 742,161
646,979 -> 646,270
14,842 -> 14,802
496,902 -> 506,912
468,354 -> 468,875
714,431 -> 714,172
554,297 -> 554,790
717,664 -> 883,664
551,182 -> 980,611
794,932 -> 499,637
384,499 -> 507,499
32,368 -> 257,368
984,131 -> 904,131
973,16 -> 10,979
189,178 -> 189,752
492,404 -> 492,593
11,515 -> 117,515
230,182 -> 230,954
652,16 -> 663,16
698,693 -> 490,693
252,942 -> 587,942
551,901 -> 428,778
899,320 -> 903,316
14,577 -> 313,278
409,576 -> 409,475
466,883 -> 819,883
221,472 -> 609,472
686,828 -> 686,720
988,989 -> 13,14
514,171 -> 227,171
868,842 -> 632,842
279,824 -> 697,406
678,464 -> 678,687
736,358 -> 736,259
933,66 -> 24,975
679,470 -> 679,689
979,953 -> 45,19
98,826 -> 737,187
612,732 -> 612,681
985,23 -> 23,985
787,732 -> 332,277
660,211 -> 660,61
395,19 -> 246,19
129,876 -> 955,50
676,246 -> 821,246
980,26 -> 18,988
142,945 -> 142,218
165,240 -> 540,240
941,522 -> 941,129
876,274 -> 876,340
627,782 -> 905,782
928,235 -> 246,235
336,449 -> 92,205
748,62 -> 748,787
804,725 -> 356,277
910,89 -> 19,980
391,99 -> 155,335
608,127 -> 516,219
337,255 -> 337,649
818,831 -> 818,859
146,204 -> 301,359
629,646 -> 906,923
87,860 -> 824,123
613,867 -> 613,946
286,339 -> 286,626
942,120 -> 595,467
35,207 -> 187,207
684,559 -> 283,158
48,768 -> 48,349
656,965 -> 656,27
865,341 -> 865,576
218,786 -> 152,786
697,69 -> 583,69
790,79 -> 552,79
310,547 -> 846,11
428,809 -> 428,940
664,829 -> 664,455
265,775 -> 749,775
362,221 -> 309,168
437,253 -> 437,597
601,324 -> 245,680
24,69 -> 24,476
420,344 -> 420,525
215,866 -> 635,866
926,770 -> 315,770
413,650 -> 413,624
751,765 -> 475,489
673,709 -> 39,75
230,689 -> 805,689
31,209 -> 789,967
698,255 -> 909,255
641,752 -> 866,527
346,780 -> 391,825
328,905 -> 328,130
628,674 -> 628,354
666,110 -> 98,678
846,651 -> 846,371
28,946 -> 28,482
289,844 -> 458,675
605,602 -> 605,297
355,217 -> 239,217
453,96 -> 195,354
988,90 -> 145,933
801,194 -> 801,109
894,708 -> 894,212
177,447 -> 607,877
824,391 -> 788,391
386,940 -> 471,855
703,425 -> 583,425
848,110 -> 36,922
603,596 -> 685,678
584,458 -> 584,482
464,903 -> 343,903
888,413 -> 405,413
320,185 -> 103,185
475,458 -> 55,878
371,843 -> 371,466
785,507 -> 785,570
904,553 -> 904,983
872,600 -> 872,848
296,693 -> 751,238
490,488 -> 322,488
37,371 -> 185,223
238,618 -> 238,883
232,89 -> 123,89
20,14 -> 961,955
794,318 -> 914,318
407,499 -> 246,338
641,514 -> 227,514
284,210 -> 562,488
164,566 -> 498,900
20,825 -> 150,955
235,384 -> 537,686
151,116 -> 979,944
697,133 -> 59,771
212,226 -> 38,226
523,527 -> 523,497
119,493 -> 352,726
927,157 -> 154,930
336,149 -> 581,394
103,580 -> 354,580
891,494 -> 532,853
22,272 -> 538,788
544,296 -> 519,271
821,382 -> 821,155
501,807 -> 501,202
588,76 -> 708,76
773,681 -> 184,681
754,936 -> 86,268
582,972 -> 40,972
530,458 -> 530,329
109,433 -> 649,433
411,215 -> 411,311
433,568 -> 433,585
232,504 -> 799,504
72,442 -> 38,442";
    }
}
