# -*- coding: utf-8 -*-
"""
Created on Fri Dec  9 10:33:24 2022

@author: Bestvision
"""

import mmap
import cv2
import numpy as np
file_name = 'test1'
byteSize = 10394
import matplotlib.pyplot as plt

class SharedMemory_Image:
    def Read_Image(file_name = 'test1',byteSize = 10394):
        f = mmap.mmap(0, byteSize, file_name, mmap.ACCESS_READ)
        img = cv2.imdecode(np.frombuffer(f, np.uint8), cv2.IMREAD_COLOR)
        #plt.imshow(img)
        #plt.show()
        f.close()
        return img

