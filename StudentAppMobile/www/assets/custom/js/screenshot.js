//document.getElementsByClassName("screen-capture-btn").onclick = function () { myFunction() };

function takeScreenShot(capDiv, imgData) {
  html2canvas(document.getElementById(capDiv)).then(canvas => {
    //console.log(canvas.toDataURL());
    document.getElementById(imgData).value = canvas.toDataURL();
  });
}


function takeScreenShot1(capDiv, imgData) {
  html2canvas(document.getElementById(capDiv)).then(canvas => {
    //console.log(canvas.toDataURL());
    document.getElementById(imgData).value = canvas.toDataURL();
    console.log("value");
    console.log(document.getElementById('saveImageBtn'));
    document.getElementById('saveImageBtn').click();  
  });
}


function takeScreenShot2(capDiv, imgData) {
  html2canvas(document.getElementById(capDiv)).then(canvas => {
    //console.log(canvas.toDataURL());
    document.getElementById(imgData).value = canvas.toDataURL();
    console.log("value");
    console.log(document.getElementById('saveImageBtn'));
    document.getElementById('saveImageBtn2').click();
  });
}
