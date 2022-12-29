# -*- coding: utf-8 -*-
"""
Created on Fri Dec  9 13:34:03 2022

@author: Bestvision
"""

import numpy as np 
import cv2

from CNN import CNN_layer
import joblib
from SharedImageUseOpenCV import SharedMemory_Image

import argparse
import sys

import os
import glob


global cnn_model,feature_extractor,RF_model
def Test(Images):
    
    SIZE = 64
    
    #--------------------
    '''im = SharedMemory_Image.Read_Image('test1',10394)
    im = cv2.resize(im, (SIZE, SIZE))
    im = cv2.cvtColor(im, cv2.COLOR_RGB2BGR)
    im = np.expand_dims(im, 0) '''   
    ###################################################################
    # Normalize pixel values to between 0 and 1
    im = Images/255.0

    #############################
    #cnn_model,feature_extractor  = CNN_layer.build_CNN()
    #cnn_model.load_weights("my_model.h5")

    #RANDOM FOREST
    #RF_model = joblib.load("random_forest.joblib")
    #Send test data through same feature extractor process
    #X_test_feature = feature_extractor.predict(x_validation)
    X_test_feature = feature_extractor.predict(im)
    #Now predict using the trained RF model. 
    prediction_RF = RF_model.predict(X_test_feature)
    return prediction_RF    

def MakeArgParser():
    parser = argparse.ArgumentParser()

    #定義每一個參數的名稱、資料型態、預設值、說明等
    
    parser.add_argument('--name', type=str, default='test1', help='The image name in the memory')
    parser.add_argument('--size', type=int, default=10394, help='Image size in the memory')
    #parser.add_argument('--timestamp', type=str, default=None, help='The File Name of Result')

    return parser

if __name__ == '__main__':     
    
    parser = MakeArgParser()
    args = parser.parse_args()
    
    
    cnn_model,feature_extractor  = CNN_layer.build_CNN()    
    
    cnn_model.load_weights("my_model.h5")
    
    #RANDOM FOREST
    RF_model = joblib.load("random_forest.joblib")
    print("開啟Model")
    name = args.name
    size = args.size
    print(name,size)
    StartRecive = False
    Images = []
    while True:
        a = input()
        if a == 'Exit':
            sys.exit(0)
        elif a == 'Start':
            print("Start Recive Image")
            StartRecive = True
        elif StartRecive == True and "/" in a:
            if "/" in a:
                a = a.split("/")
                #print("From Python: " + a[0],int(a[1]))
                im = SharedMemory_Image.Read_Image(a[0],int(a[1]))
                im = cv2.resize(im, (64, 64))
                Images.append(im)
            
        elif a == 'End':
            print("From Python: Images shape = :" + str(len(Images)))
            StartRecive = False
        elif a == 'Classify':
            validation_images = []
            validation_labels = [] 
            for directory_path in glob.glob("Images/Validation/*"):
                validation_label = directory_path.split("\\")[-1]
                for img_path in glob.glob(os.path.join(directory_path, "*.jpg")):
                    img = cv2.imread(img_path, cv2.IMREAD_COLOR)
                    img = cv2.resize(img, (64, 64))
                    img = cv2.cvtColor(img, cv2.COLOR_RGB2BGR)
                    validation_images.append(img)
                    validation_labels.append(validation_label)
            validation_images = np.array(validation_images)
            validation_labels = np.array(validation_labels)
            Result = Test(validation_images)
            print(Result)
        #print("output :" + a)
