import base64
import numpy as np
import matplotlib.pyplot as plt

def shennonhartly(path):
	with open(path) as f:
		a = np.array(list(f.read()))
	b,cnt = np.unique(a, return_counts = True)
	p = cnt / np.sum(cnt)
	zip_iterator = zip(b,cnt)
	value_dict = dict(zip_iterator)
	plt.bar(list(value_dict.keys()), value_dict.values(), color = 'r')
	plt.show()
	shennon = -np.sum(p * np.log2(p)) # Шеннон
	hartly = np.log2(len(b)) # Хартли
	overfill = (hartly - shennon/hartly) * 100
	print(b)
	print(cnt)
	print("Энтропия Шеннона: ", shennon)
	print("Энтропия Хартли: ", hartly)
	print("Избыточность: ", overfill)


def xor(a, b):
	a = list(a)
	b = list(b)
	if (len(a) > len(b)):
		for i in range(len(a) - len(b)):
			b.append(0)
	if (len(b) > len(a)):
		for i in range(len(b) - len(a)):
			a.append(0)
	result = set(b) ^ set(a)
	return result

with open("input.txt") as f:
	input_string = f.read()

input_string_bytes = input_string.encode('ascii') 
base64_bytes = base64.b64encode(input_string_bytes) # кодируем в base64
base64_string = base64_bytes.decode('ascii') # раскодируем

with open("output.txt","w") as output:
	output.write(base64_string)

print("Начальная строка: ", input_string)
print("Итоговая строка: ", base64_string)

print()
print()
print()

shennonhartly("input.txt")

print()
print()
print()

shennonhartly("output.txt")

print()
print()
print()

a = "Garelskiy"
b = "Vladislav"
a_ascii = a.encode('ascii')
a_base64 = base64.b64encode(a_ascii)
b_ascii = b.encode('ascii')
b_base64 = base64.b64encode(b_ascii)
res = xor(a_ascii, b_ascii)
print(res)

print()
print()
print()

res = xor(a_base64, b_base64)
print(res)