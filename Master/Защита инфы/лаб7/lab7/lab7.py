import random

import numpy as np

import funcs
import funcs7

x = np.array([1, 1, 1, 0, 1, 0, 1, 0, 1])
print(x)
columns = 5

chunks = funcs7.split_and_encode(x, 3, 3)
print('encoded chunks: ')
print(chunks)

xn = chunks.flatten()
shuffled, rows = funcs7.shuffle(xn, 3)
print('shuffled')
print(shuffled)

deshuffled, _ = funcs7.shuffle(shuffled, rows)
print('deshuffled')
print(deshuffled)

print('3 errors:')
startpos = random.randint(0, xn.__len__()-4)
endpos = startpos + 2

print(str(startpos+1) + ' - ' + str(endpos+1))
shuffled_with_errors = shuffled.copy()
for i in range(startpos, endpos+1):
    shuffled_with_errors[i] = funcs.invert(shuffled_with_errors[i])
print('shuffled')
print(shuffled)
print('shuffled with errors')
print(shuffled_with_errors)
deshuffled_with_errors, _ = funcs7.shuffle(shuffled_with_errors, rows)
print('deshuffled with errors')
print(deshuffled_with_errors)
deshuffled = funcs7.split_and_decode(deshuffled_with_errors, 5, 3)
print ('deshuffled without errors')
print(deshuffled)