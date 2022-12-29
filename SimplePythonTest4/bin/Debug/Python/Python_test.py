import numpy as np 
import cv2

import joblib

import argparse
import sys

import os
import glob


def MakeArgParser():
    parser = argparse.ArgumentParser()

    #定義每一個參數的名稱、資料型態、預設值、說明等
    
    parser.add_argument('--name', type=str, default='test1', help='The image name in the memory')
    parser.add_argument('--size', type=int, default=10394, help='Image size in the memory')    

    return parser

if __name__ == '__main__':     
    
    parser = MakeArgParser()
    args = parser.parse_args()          

    name = args.name
    size = args.size
    print(name,size)

    while True:
        a = input()
        if a == 'Exit':
            sys.exit(0)
        elif a == 'Start':
            print("Start Recive Image")
             
        elif a == 'End':
            print("End !")                   