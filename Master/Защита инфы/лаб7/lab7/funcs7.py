import math
import cycliccode
import numpy as np

g = np.array([1, 1, 1])
cc = cycliccode.cycliccode(g, 5)
r = 2
def shuffle(msg, columns):
    rows = math.ceil(msg.__len__()/columns)
    matrix = np.zeros((rows, columns)).astype(int)
    k = 0;
    for i in range(rows):
        for j in range(columns):
            matrix[i,j] = msg[k]
            k+=1
    print('msg fit into matrix')
    print(matrix)

    end_msg = []

    transposed = matrix.transpose();
    for i in range(columns):
        for j in range(rows):
            end_msg.append(transposed[i,j])
    return np.array(end_msg), rows


def split_and_encode(x, split_by: int, times: int):
    result = []
    for i in range(times):
        word = []
        for j in range(split_by):
            word.append(x[i*split_by+j])
        word = np.array(word)
        encoded_msg = cc.c(word)
        result.append(encoded_msg)
    return np.array(result)


def split_and_decode(x, split_by: int, times: int):
    result = []
    for i in range(times):
        word = []
        for j in range(split_by):
            word.append(x[i*split_by+j])
        word = np.array(word)
        decoded_msg = cc.syndromeDecode(word)
        result.append(decoded_msg)
    return np.array(result)

