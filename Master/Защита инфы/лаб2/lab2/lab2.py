import numpy as np
import matplotlib.pyplot as plt
import binascii

with open("input_binary.txt", "w") as binar:
	binar.write(bin(int.from_bytes('Garelskiy Vladislav Viktorovich'.encode(),'big')))

with open("input.txt") as f: #taskA (рассчитать энтропию алфавита)
	a = np.array(list(f.read()))

massive, frequency = np.unique(a, return_counts = True)
p = frequency / np.sum(frequency)
zip_iterator = zip(massive, frequency)
value_dict = dict(zip_iterator)
plt.bar(list(value_dict.keys()), value_dict.values(), color = 'r')
plt.show()
entr_letters = -np.sum(p * np.log2(p))
print(massive)
print(frequency)
print(entr_letters)

print("-------------------------------------------------")

with open("input_binary.txt") as f: #taskB (рассчитать энтропию бинарного алфавита)
	a = np.array(list(f.read()))
with open("input_binary.txt") as f:
	word_bit = f.read()	
a = list(a)
a.remove('b')
word = int(word_bit, 2).to_bytes((int(word_bit, 2).bit_length()+7)//8, 'big').decode()
massive, frequency = np.unique(a, return_counts = True)
p = frequency / np.sum(frequency)
zip_iterator = zip(massive, frequency)
value_dict = dict(zip_iterator)
plt.bar(list(value_dict.keys()), value_dict.values(), color = 'r')
plt.show()
entr_binary = -np.sum(p * np.log2(p))
print(massive)
print(frequency)
print(entr_binary)

print("-------------------------------------------------")

s = list('Bozhko Denis Vladimirovich') #taskC (кол-во информации в Bozhko Denis Vladimirovich)
len_s = len(s)
s_to_bin = bin(int.from_bytes('Bozhko Denis Vladimirovich'.encode(),'big'))
len_bin_s = len(s_to_bin)
inf_letters = entr_letters * len_s
inf_binary = entr_binary * len_bin_s
print(inf_letters)
print(inf_binary)

print("-------------------------------------------------")

p1 = 0.1 #taskD (taskC при условии, что есть вероятность ошибочной передачи бита)
p2 = 0.5
p3 = 1

print("\n")

print(inf_letters * (1 - p1))
print(inf_binary * (1 - p1))
print("-----------------------")
print(inf_letters * (1 - p2))
print(inf_binary * (1 - p2))
print("-----------------------")
print(inf_letters * (1 - p3))
print(inf_binary * (1 - p3))

print("\n")