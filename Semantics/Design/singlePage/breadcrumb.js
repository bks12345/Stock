/*
* Created by Yogesh on 2015/7/29 1:59PM
*
* Instructions:
* The breadcrumnb is intended to be used only for the sections with use of section ids
* The label in the breadcrumb will be same as that of the id provided for now, so it is 
* recommended that the id is given according to the label for the breadcrumb.
* 
* Setup: include this js file in your html page
* call the function setHomePage(yourHomePageId); 
*
* define onscroll = "javascript:givePageStatus()" on the body tag, 
* or which ever is the main scrolling tag.
* 
* No css have been defined and is a raw working prototype.
*
* 	NOTE: 	Plugin has not been tested with jQuery and is a core javascript plugin
*		 	and is developed for specific requirement only. Change in requirements 
*        	may require change in the programmitical logic.
*
*/
window.onload = function () { givePageStatus(); }
window.onscroll = function () {  givePageStatus(); }
//array to hold the breadcrumb items
var breadCrumbArray = new Array();
//the breadcrumb displaying list
var breadCrumblist = document.getElementById('breadcrumb_list');

var homePage = "";

var currentSection = "";

//set the home page id of the working page
function setHomePage(home){
    homePage = home;
}

//method get the current status of the page and change the breadcrumb accordingly
function givePageStatus(){

		var pageUrl = window.location.href;

		if(pageUrl.split("#").length > 1){

		    if (pageUrl.split("#")[1] = "") 
            {
		        return false;
              }
	    
			if(pageUrl.split("#")[1] == homePage){
				if(currentSection != homePage){
					currentSection = homePage;
					processArray(currentSection);

					//console.log(homePage);
					//console.log(breadCrumbArray);
				}
				
			}
			else{
				if(currentSection != pageUrl.split("#")[1]){
					
					currentSection = pageUrl.split("#")[1];
					processArray(currentSection);

					//console.log(pageUrl);
					//console.log(pageUrl.split("#")[1]);
					//console.log(breadCrumbArray);
				}
			}
		}
		else{
			if(currentSection != homePage){
					
					currentSection = homePage;
					processArray(currentSection);

					//console.log(pageUrl);
					//console.log("Hello you are at home page");
					//console.log(breadCrumbArray);
				}
		}
	
		
}

//Method to process the clicked id value
//check if the value is alreday present in the breadCrumbArray or is a new item of the breadCrumbArray
//
function processArray(clickedSection){
	//check if the section is already in our breadcrumb array 
	var position = checkValueInArray(clickedSection);
	var tempBuffer = new Array();
	if(position > -1){
		//yes we have 
		//remove all the other sections beyond the cicked section
		for	(var index = 0; index < position; index++) {
		    tempBuffer.push(breadCrumbArray[index]);
		}

		breadCrumbArray = tempBuffer;

	}
	else{
		//add the breadcrumb to the array
		breadCrumbArray.push(clickedSection);
	}

	updateUI();
}

//method to check the value in the breadCrumbArray
// @param valueToCkeck
//           the clicked section id
//return -1 if not found, else the index of the value in the breadCrumbArray	
function checkValueInArray(valueToCkeck){

	for	(var index = 0; index < breadCrumbArray.length; index++) {
		    if(valueToCkeck == breadCrumbArray[index]){
		    	return index+1;
		    }
		}

		return -1;
}

//Method to update the list items
// According to the refereshed breadCrumbArray, rearrange the items in the breadcrumb list 
function updateUI(){
	//change the breadcrumb list of links here
	//must be called after the processArray() has finished refreshing the breadCrumbArray

	//first remove child elements
	var list = document.getElementById("breadcrumb_list");
	//console.log(list.childNodes.length +" nodes");
	while (list.hasChildNodes()) {  
    list.removeChild(list.firstChild);
	}

	//then add the new elements to the list
	for(var index = 0; index < breadCrumbArray.length ; index++){
		var node = document.createElement("LI");

		var link = document.createElement("a");
		link.setAttribute("href","#"+breadCrumbArray[index]);
		var textnode = document.createTextNode(breadCrumbArray[index]);
		link.appendChild(textnode);

		node.appendChild(link);    

		list.appendChild(node);   
	}
    

}


