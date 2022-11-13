
from numpy.polynomial import polynomial as P
import math
import numpy as np

# вычисляем длину строки
def str_len(X_k):
	k = len(X_k)
	print('Длина сообщения = "',k,'"')
	return k 

# вычисляем r 
R_Culc = {
	'test':3,
	'4':5
}

# добавочный полином
def Edition_R_Polinom(r):
	r_poly = []
	for i in range(r):
		r_poly.append(0)
	r_poly.append(1)
	print('Полином для умножения = ',r_poly)
	return r_poly

# получаем начальную строку в виде массива
def str_to_arr(string):
	X_k_list = list(string)
	X_k_list = list(map(int,X_k_list))
	return X_k_list

# полином
Poly = {
	'test':[1,1,0,1],
	'4':[1,0,0,1,0,1]
}

# умножение полиномов
def multiply_result(poly_1,poly_2):
	return P.polymul(poly_1,poly_2)

# деление полиномов
def division_result(poly_1,poly_2):
	res = P.polydiv(poly_1,poly_2)
	res = [abs(elem) for elem in res]
	return res

# добавление остатка к исходному сообщению
def FinalMessage(poly_1,poly_2):
	res = []
	res.extend(poly_2)
	res.extend(poly_1)
	return res

# проверка ошибки
def Mistake_Check(Message, EncodePoly):
	res = division_result(Message,EncodePoly)
	print(res)
	for i in res[1]:
		if int(i)==1 or int(i)==-1:
			return 0
	return 1

# генерация матрицы
def GenerateMatrix(K_R,K,poly):
	
	Matrix = [ [0]*K_R for i in range(K)]
	for i in range(K):
		Matrix[i]=poly
		poly=[poly[-1]] + poly[:-1]
	for i in range(K-1):
		for j in range(i+1,K):
			if Matrix[i][j]==1:
				Matrix[i] = list(np.array(Matrix[i])+np.array(Matrix[j]))
				for m in range(K):
					for l in range(K_R):
						if Matrix[m][l]%2==0:
							Matrix[m][l]=0
	
	return Matrix

# подматрица H
def SubMatrixH(K,R,Matrix):
	H = []
	for i in range(K):
		for j in range(K,K+R):
			H.append(Matrix[i][j])
	
	H = np.reshape(H,(K,R))
	H = np.concatenate((H,np.eye(R,dtype=int).reshape((R,R))))
	return H

# исправление ошибок
def ClearMistake(K_R,K,Fin_message,curr_poly):
	poly_for_matrix = curr_poly.copy()
	poly_for_matrix.reverse()
	for i in range(K_R-K):
		poly_for_matrix.append(0)
	matr = GenerateMatrix(K_R,K,poly_for_matrix)
	#print(matr)
	H = SubMatrixH(K,K_R-K,matr)
	print(H)
	divres = division_result(Fin_message,curr_poly)
	divres = list(map(int,divres[1]))
	if len(divres)!=K:
		for i in range(K-len(divres)):
			divres.append(0)
	print(divres)
	E = []
	index = 99999
	for i in range(K_R):
		if divres==list(H[i]):
			index = i;
	print(index)
	for i in range(K_R):
		if i==index:
			E.append(1)
		else:
			E.append(0)
	E.reverse()
	print(E)
	Corrected_Message = list(np.array(Fin_message)+np.array(E))
	for i in range(len(Corrected_Message)):
		if Corrected_Message[i]%2 == 0:
			Corrected_Message[i]=0
	print(Corrected_Message)

# сбор всего
def Cycle_Code(X_k):
	X_k_list = str_to_arr(X_k)
	K = str_len(X_k)
	curr_r = R_Culc['4']
	r_poly = Edition_R_Polinom(curr_r)
	curr_poly = Poly['4']
	X_k_mul_X_Pow_R = list(map(int,multiply_result(X_k_list,r_poly)))
	print('Строка с избыточными битами = ',X_k_mul_X_Pow_R)
	div_res = division_result(X_k_mul_X_Pow_R,curr_poly)
	print(div_res)
	Fin_message = FinalMessage(X_k_list,list(map(int,div_res[1])))
	print('Итоговая строка = ',Fin_message)
	
	Fin_message = [1, 0, 1, 1, 1, 1, 0, 1, 0, 1]
	if Mistake_Check(Fin_message,curr_poly)==1:
		print('Ошибок нет') 
	else:
		print('Есть ошибка')
		ClearMistake(K+curr_r,K,Fin_message,curr_poly)	

	
def main():
	X_k = '10101'
	print('Сообщение = "',X_k,'"')
	Cycle_Code(X_k)

main()