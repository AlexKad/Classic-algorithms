//O(logN)
function binarySearch(arr, value){
	var startInd = 0,
		stopInd = arr.length -1,
		middle = Math.floor((startInd + stopInd)/2);

	while(arr[middle] != value && startInd<stopInd){
		if(value<arr[middle]) { stopInd = middle - 1; }
		else if(value>arr[middle]) {
			startInd = middle + 1;
		}
		middle = Math.floor((startInd + stopInd)/2); 
	}

	 return (arr[middle] != value) ? -1 : middle;
}