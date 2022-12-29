# -*- coding: utf-8 -*-
"""
Created on Thu Dec  8 11:42:44 2022

@author: Bestvision
"""


from tensorflow.keras.models import Model, Sequential
from tensorflow.keras.layers import Dense, Flatten, Conv2D, MaxPooling2D
from keras.layers.normalization import BatchNormalization

class CNN_layer:
    
    def build_CNN(SIZE = 64):
        activation = 'ReLU'

        feature_extractor = Sequential()
        feature_extractor.add(Conv2D(32, 3, activation = activation, padding = 'same', input_shape = (SIZE, SIZE, 3)))
        feature_extractor.add(BatchNormalization())

        feature_extractor.add(Conv2D(32, 3, activation = activation, padding = 'same', kernel_initializer = 'he_uniform'))
        feature_extractor.add(BatchNormalization())
        feature_extractor.add(MaxPooling2D())

        feature_extractor.add(Conv2D(64, 3, activation = activation, padding = 'same', kernel_initializer = 'he_uniform'))
        feature_extractor.add(BatchNormalization())

        feature_extractor.add(Conv2D(64, 3, activation = activation, padding = 'same', kernel_initializer = 'he_uniform'))
        feature_extractor.add(BatchNormalization())
        feature_extractor.add(MaxPooling2D())

        feature_extractor.add(Conv2D(128, 3, activation = activation, padding = 'same', kernel_initializer = 'he_uniform'))
        feature_extractor.add(BatchNormalization())

        feature_extractor.add(Conv2D(128, 3, activation = activation, padding = 'same', kernel_initializer = 'he_uniform'))
        feature_extractor.add(BatchNormalization())
        feature_extractor.add(MaxPooling2D())

        feature_extractor.add(Flatten())

        #Add layers for deep learning prediction
        x = feature_extractor.output  
        x = Dense(128, activation = activation, kernel_initializer = 'he_uniform')(x)
        prediction_layer = Dense(2, activation = 'softmax')(x)

        # Make a new model combining both feature extractor and x
        cnn_model = Model(inputs=feature_extractor.input, outputs=prediction_layer)
        cnn_model.compile(optimizer='Adam',loss = 'categorical_crossentropy', metrics = ['accuracy'])        
        
        
        return cnn_model, feature_extractor