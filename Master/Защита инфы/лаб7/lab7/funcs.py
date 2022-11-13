import itertools as perms
import math

import numpy as np


def str_to_int_arr(x: str):
    return np.array([int(symbol) for symbol in x])


def generate_square_matrix(r):
    matrix = np.zeros((r, r))
    np.fill_diagonal(matrix, 1)
    return matrix


def binary_permutations(lst):
    for comb in perms.combinations(range(len(lst)), lst.count(1)):
        result = [0] * len(lst)
        for i in comb:
            result[i] = 1
        yield result


def search_2D(matrix, B):
    column_num = 0
    for column in matrix:
        if np.array_equal(B, column):
            return column_num
        column_num += 1


def to_binary(a):
    l, m = [], []
    for i in a:
        l.append(ord(i))
    for i in l:
        m.append(int(bin(i)[2:]))
    return m


def int_array_to_str(arr):
    res = ""
    for num in arr:
        res += str(num)
    return res


def char_and(a, b):
    if (a == '1' or a == 1) and (b == '1' or b == 1):
        return True
    else:
        return False


def xor(a, b):
    if (a == b):
        return True
    else:
        return False


# def sum_xor(items_list):
#     items_list_copy = list(items_list)
#     xor_result = items_list_copy.pop()
#     while items_list_copy.__len__() > 0:
#         xor_result = xor(xor_result, items_list_copy.pop())
#     # or just filter(result == 1) and check if length % 2 == 0 or 1
#     return xor_result
def sum_xor(word: np.ndarray):
    ones_count = np.count_nonzero(word)
    return ones_count % 2 == 1


def invert(x):
    if x == 0 or x == '0':
        return 1
    else:
        return 0


def get_xr(matrix_perms, x):
    xr = []
    for row in matrix_perms:
        seq = zip(row, x)
        result = (list(char_and(x, y) for x, y in seq))
        xr.append(sum_xor(result))
    return np.array(xr).astype(int)


def message_to_binary_array(msg: str):
    msg = np.array(to_binary(msg)).flatten()
    return int_array_to_str(msg)


def count_r(xlen: int):
    r = np.round_(math.log2(xlen), 0) + 1
    r = int(r)
    return r


def generate_h_matrix(xlen: int):
    permCount = 0
    matrixPerms = [[]]
    onesCounter = 2
    r = count_r(xlen)
    rMatrix = generate_square_matrix(r)
    while permCount < xlen:
        permsSeq = np.concatenate((np.ones(onesCounter), np.zeros(r - onesCounter)))
        currentPerms = list(binary_permutations(permsSeq.tolist()))
        permCount += currentPerms.__len__()
        onesCounter += 1
        matrixPerms.append(currentPerms)

    matrixPerms = matrixPerms[1:]
    matrixPerms = list(perms.chain.from_iterable(matrixPerms))
    matrixPerms = np.transpose(np.array(matrixPerms[:xlen]))
    matrix = np.concatenate((matrixPerms, rMatrix), axis=1).astype(int)
    return matrix, r


def syndrome(yn: str, xlen: int, matrix):
    y = yn[:xlen]
    yr = yn[xlen:]
    yrnew = get_xr(matrix, y)
    return calc_syndrome(yr, yrnew, xlen)


def calc_syndrome(yr: str, yrnew: str, xlen: int):
    return np.logical_xor(yrnew, yr).astype(int)
