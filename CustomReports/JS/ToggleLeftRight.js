

function ToggerLeft(objtd) {
    //if ($("#mainframe").cols == "220,12,*") {
    //    $("#mainframe").cols = "0,12,*";
    //    objtd.innerHTML = '&gt;';
    //}
    //else {
    //    $("#mainframe").cols = "220,12,*";
    //    objtd.innerHTML = '&lt;';
    //}
    if (window.parent.mainframe.cols == "220,12,*")
    {
        top.mainframe.cols = "0,12,*";
       // document.getElementById('menuSwitch').innerHTML = "<img src='Images/expand.png' width=16 height=16>";
        $("#menuSwitch").innerHTML = "<img src='Images/expand.png' width=16 height=16>";
    }
    else
    {
        top.mainframe.cols = "220,12,*";
        //document.getElementById('menuSwitch').innerHTML = "<img src='Images/Hide.png' width=16 height=16>";
        $("#menuSwitch").innerHTML = "<img src='Images/Hide.png' width=16 height=16>";
    } 

   
}

function ToggerLeft2(objtd) {
 
    window.parent.document.getElementById("#mainframe").cols = ("1,12,*");
        
}