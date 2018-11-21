"use strict"
var fs = require('fs');
var Enumerable = require('linq-es2015');

function Frequencies(alphabetText, k){
	let sortedFreq = Enumerable.asEnumerable(alphabetText)
			.GroupBy(str => str.toUpperCase())          
			.Select(g => [g.length, g.key])    
			.OrderByDescending(kc => kc[0]).ThenBy(kc => kc[1]).Take(k)
			.ToArray()
			;
	return sortedFreq;	
}

function Main(){
	let args = process.argv;
	let textFile = args[2];
	let k = 3;
	if(args.length == 4){
		k = args[3];
		if(isNaN(k)){ //throw exception if k is not a number
			throw "NaNException";
		}
		else if(k < 0){
			throw "negativeException";
		}
	}
	let rawText = fs.readFileSync(textFile, 'utf8');
	let alphabetText = rawText.replace(/[^a-zA-Z]+/g, " ").trim().split(' ');
	
	let sortedFreq = Frequencies(alphabetText, k);
	sortedFreq.forEach(keyCount => console.log(keyCount[0].toString(), keyCount[1]));
}

try{
	Main();
}
catch(exception){
	if(exception.code === "ENOENT"){
		console.log("***Error: Specified text file does not exist in this directory.");
	}
	else if(exception === "NaNexception"){
		console.log("***Error: Optional parameter provided is not an Integer.");
		if(!fs.existsSync(process.argv[2])){ //check if file exists 
			console.log("***Error: Specified text file does not exist in this directory.");
		}
	}
	if(exception === "negativeException"){
		console.log("*** Error: No output; negative k value entered.");
	}
	if(exception instanceof TypeError){
		console.log("*** Error: Missing text file name.");
	}
}