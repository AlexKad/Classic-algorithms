//bubble

Array.prototype.swap = function(ind1, ind2){
	if(this.length>ind1 && this.length>ind2){
		var t = this[ind1];
		this[ind1] = this[ind2];
		this[ind2] = t;
	}	
}

//O(n^2)   memory O(1)
function BubbleSort(arr){
	var swapped;
	do{
		swapped = false;
		for(var i=1; i<arr.length; i++){
			if (arr[i]<arr[i-1]) {
				arr.swap(i, i-1);
				swapped = true;
			}
		}
	}
	while (swapped == true);
    return arr;
}


//O(n^2)  memory O(n)   left is always sorted. find index in left part and push current item here
function InsertSort(arr){
	var value, length = arr.length;
	for(var i=0; i<length; i++){
		value = arr[i];
		for(var j = i-1; j>-1 && arr[j]>value; j--){
			arr[j+1] = arr[j];
		}
		arr[j+1] = value;
	}
	return arr;
}



//O(NlogN)    left side is sorted. Find in right part min elem and swap with current
function SelectionSort(arr){
	var min, i, j, length = arr.length;
	for(i=0; i<length; i++){
		min = i;
		for(j = i+1; j<length; j++){
			if(arr[j]<arr[min]) min = j;
		}		
		arr.swap(i, min);
	}
	return arr;
}


//O(NlogN) Memory O(N) Merge Sort

function Merge(left, right){

}
function MergeSort(arr){

}


//O(NlogN)  Memory O(1) QuickSort

function partition(arr, left, right){
	var pivot = arr[Math.floor((right+left)/2)],
		i = left,
		j = right;

		while(i<=j){
			while(arr[i]< pivot)  i++;
			while(arr[j]> pivot)  j--;

			if(i<=j){
				arr.swap(i,j);
				i++;
				j--;
			}
		}		
	return i;
}

function QuickSort(arr, left, right){
	var index;
	if(isNaN(left) && isNaN(right)){
		left = 0;
		right = arr.length-1;
	}

	if(arr.length>1){		
		index = partition(arr, left, right);
		if(left < index-1){
			QuickSort(arr,left, index-1);			
		}
		if(index < right){
			QuickSort(arr, index, right);
		}
	}
	return arr;
}