import numpy as np
import time
def Shift(seq, shift=1):
    return seq[-shift:] + seq[:-shift]

def Get_Last_Col(Arr):
	res =""
	for i in Arr:
			res += i[-1]
	return res

def Burrows_Wheeler_Transform(string):
	time1 = time.time()

	###VAR###
	string_index = 0;
	str_list = []
	
	###SOLUTION###
	print()
	print('---------прямое преобразование---------')
	print()
	print('Исходное сообщение : ',string)
	for i in range(len(string)):
		str_list.append(Shift(string,i))
	#print(str_list)
	str_list.sort()
	for i in range(len(str_list)):
		if str_list[i].__eq__(string):
			string_index = i
	arr = [list(i) for i in str_list]
	arr = np.array(arr)
	res = Get_Last_Col(str_list)
	print(arr)
	print('Номер нашего сообщения: ',string_index+1)
	print('Выходное сообщение: ',res)
	A=[string_index,res]
	time2 = time.time()
	print('Время выполнения прямого прербразования: ', (time2 - time1)*1000)
	return A

def Burrows_Wheeler_Transform_Back(string, position):
	time1 = time.time()

	###VAR###
	string_index = 0;
	str_list = []
	
	###SOLUTION###
	print()
	print('---------обратное преобразование---------')
	print()
	for i in range(len(string)):
		str_list.append(string[i])
		str_list.sort()
	for i in range(len(string)-1):
		for j in range(len(string)):
			str_list[j]=string[j]+str_list[j]
		str_list.sort()
		#print(str_list)
		arr = [list(i) for i in str_list]
		arr = np.array(arr)
		print(arr)
	result = str_list[position]
	print('Раскодированная строка: ', result)
	time2 = time.time()
	print('Время выполнения прямого преобразования: ', (time2 - time1)*1000)
	

def main():	
	#Message = 'столб'
	Message = 'денис'
	#Message = 'божко'
	#Message = 'времяпрепровождение'
	RES = Burrows_Wheeler_Transform(Message)
	Burrows_Wheeler_Transform_Back(RES[1],RES[0])
main()