﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Програма реалізована  на його основі, суть алгоритму найти найменше значення та відносно знайденого числа,
 у подальшому програма складає алкоритм*/
namespace SHILab5
{
    class Traveler
    {
        int[,] distancias = new int[,]
        {   //Мапа відстані між містами, 0 - місто в якому знаходимося, саме тому в подальшій реалізації алгоритму коли вичисляємо мінімальне значення, не враховуємо нуль
            //
                { 0, 868, 125, 748, 366, 256, 316, 1057, 360, 471, 428, 593, 311, 844, 232, 734, 521, 120, 343, 312 },       //Вінниця
                { 868, 0, 858, 217, 1171, 727, 520, 148, 1221, 611, 731, 390, 1045, 591, 1100, 335, 560, 988, 547, 1141 },   //Донецьк
                { 125, 858, 0, 738, 431, 131, 407, 1182, 423, 677, 557, 468, 187, 803, 298, 690, 624, 185, 321, 389 },       //Житомир
                { 748, 217, 738, 0, 1119, 607, 303, 365, 833, 377, 497, 270, 925, 365, 977, 287, 297, 875, 405, 957 },       //Запоріжжя
                { 366, 1171, 431, 1119, 0, 561, 618, 1402, 135, 747, 627, 898, 296, 1070, 134, 1040, 798, 246, 709, 143 },   //Ів-Франківськ
                { 256, 727, 131, 607, 561, 0, 298, 811, 550, 490, 489, 337, 318, 972, 427, 478, 551, 315, 190, 538 },        //Київ
                { 316, 520, 407, 303, 618, 298, 0, 668, 710, 174, 294, 246, 627, 570, 547, 387, 225, 435, 126, 637 },        //Кіровоград
                { 1057, 148, 1182, 365, 1402, 811, 668, 0, 1379, 857, 977, 474, 1129, 739, 1289, 333, 806, 1177, 706, 1292 },//Луганськ
                { 360, 1221, 423, 833, 135, 550, 710, 1379, 0, 850, 970, 891, 232, 1173, 128, 1028, 1141, 240, 740, 278 },   //Львів
                { 471, 611, 677, 377, 747, 490, 174, 857, 850, 0, 120, 420, 864, 282, 754, 556, 51, 590, 300, 642 },         //Миколаїв
                { 428, 731, 557, 497, 627, 489, 294, 977, 970, 120, 0, 540, 741, 392, 660, 831, 171, 548, 420, 515 },        //Одеса
                { 593, 390, 468, 270, 898, 337, 246, 474, 891, 420, 540, 0, 665, 635, 825, 141, 471, 653, 279, 892 },        //Полтава
                { 311, 1045, 187, 925, 296, 318, 627, 1129, 232, 864, 741, 665, 0, 1157, 162, 805, 834, 193, 508, 331 },     //Рівне
                { 844, 591, 803, 365, 1070, 972, 570, 739, 1173, 282, 392, 635, 1157, 0, 1097, 652, 221, 964, 696, 981 },    //Сімферополь
                { 232, 1100, 298, 977, 134, 427, 547, 1289, 128, 754, 660, 825, 162, 1097, 0, 987, 831, 112, 575, 176 },     //Тернопіль
                { 734, 335, 690, 287, 1040, 478, 387, 333, 1028, 556, 831, 141, 805, 652, 987, 0, 576, 854, 420, 1036 },     //Харків
                { 521, 560, 624, 297, 798, 551, 225, 806, 1141, 51, 171, 471, 834, 221, 831, 576, 0, 641, 351, 713 },        //Черсон
                { 120, 988, 185, 875, 246, 315, 435, 1177, 240, 590, 548, 653, 193, 964, 112, 854, 641, 0, 463, 190 },       //Хмельницький
                { 343, 547, 321, 405, 709, 190, 126, 706, 740, 300, 420, 279, 508, 696, 575, 420, 351, 463, 0, 660 },        //Черкаси
                { 312, 1141, 389, 957, 143, 538, 637, 1292, 278, 642, 515, 892, 331, 981, 176, 1036, 713, 190, 660, 0 }      //Чернівці
        };

        string[] cities = new string[]
        {
                "Вiнниця", "Донецьк", "Житомир", "Запорiжжя", "Iв-Франкiвськ", "Київ", "Кiровоград", "Луганськ", "Львiв", "Миколаїв", "Одеса",
                "Полтава", "Рiвне", "Сiмферополь", "Тернопiль", "Харкiв", "Херсон", "Хмельницький", "Черкаси", "Чернiвцi"
        };

        public string GetRoute()
        {
            int[] min = new int[20];
            int[] indexJ = new int[20];

            //Шукаємо максимальні значення кожного рядка
            for (int i = 0; i < distancias.GetLength(0); i++)
            {
                min[i] = distancias[i, 0];
                for (int j = 1; j < distancias.GetLength(1); j++)
                {

                    if (distancias[i, j] > min[i])
                    {
                        min[i] = distancias[i, j];
                    }
                }
            }


            int a = 0;
            int b = 0;

            //знаходимо мінімальні, які не нуль та їхній індекс, запамятовуємо індекс, щоб алгоритм змінив місто 
            for (int i = 0; i < distancias.GetLength(0); i++)
            {
                for (int j = 0; j < distancias.GetLength(1); j++)
                {
                    if (distancias[i, j] < min[i] && distancias[i, j] != 0)
                    {
                        min[i] = distancias[i, j];
                        indexJ[a] = j;
                    }
                }


                //очищаємо попередні мінімальні нулем, щоб не поїхне у одне і теж місто двічі)
                for (int k = 0; k < distancias.GetLength(0); k++)
                {
                    distancias[k, 0] = 0;
                    if (b != 0)
                    {
                        --a;
                        distancias[k, indexJ[a]] = 0;
                        ++a;
                    }
                }

                i = --indexJ[a];
                ++indexJ[a];
                a++;
                b++;
                if (b == distancias.GetLength(0))
                {
                    break;
                }
            }

            a = 0;
            string aa = "";
            aa += cities[0].ToString();

            for (int i = 0; i < 18; i++)
            {
                aa =  aa + " ->\n" + cities[indexJ[a]].ToString();
                a++;
            }

            return aa;
        }   
    }
}