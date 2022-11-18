

function run(){
    var word_case = document.getElementById('word_case');
    var word_case_inner = word_case.value;
 
    var section = document.getElementById('section');
    section.style.display = 'inline-block';

  
   
    for(let i = 0; i< word_case_inner.length;i++){
        section.innerHTML ='<div id="section"><span>' + word_case_inner +  
        " " + '</span></div>' + '<br>' +  section.innerHTML;
    }

    for(let i = 0; i< word_case_inner.length;i++){
        section.innerHTML ='<div ><span>' + word_case_inner +  
        " " + '</span></div>' + '<br>' +  section.innerHTML;
    }

    
        
   


   
    
    
}