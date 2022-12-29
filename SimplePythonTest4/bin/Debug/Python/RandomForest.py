# -*- coding: utf-8 -*-
"""
Created on Thu Dec  8 11:45:48 2022

@author: Bestvision
"""

from sklearn.ensemble import RandomForestClassifier

class RF_layer:
    def build_RF(estimators = 89, random_state = 42):        
        RF_model = RandomForestClassifier(n_estimators = estimators, random_state = random_state)
        return RF_model