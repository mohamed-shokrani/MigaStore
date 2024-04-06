﻿
const uplodaImageBtn = document.getElementById("upload-images");
const uplodaImageMethod = document.getElementById("upload-method");
const imagesArray = document.getElementById("images-array");

let files = [];
uplodaImageBtn.addEventListener("click", (e) => {
    e.preventDefault();
    openDialog();
});
function openDialog() {
    document.getElementById("upload-method").click();
    
   

};
uplodaImageMethod.addEventListener("change", (e) => {
    files = uplodaImageMethod.files;
    let checkfiles = uplodaImageMethod.files;
    console.log(checkfiles);
    for (var i = 0; i < files.length; i++) {

       let file = files[i];
        console.log(file.name);

        const reader = new FileReader();
        reader.onload = function (e) {
            const img = document.createElement("img");
            const cancelBtn = document.createElement("span");
            const imgContainer = document.createElement("div");
            


            img.src = e.target.result;
            img.alt = file.name;
            img.style.maxWidth = "200px";
            img.className ="product-image"
            cancelBtn.className = "cancelBtn";
            cancelBtn.innerHTML = "&times;";

            imgContainer.className = "img-container"
            imagesArray.appendChild(imgContainer);
            imgContainer.appendChild(cancelBtn)
            imgContainer.appendChild(img);
            uplodaImageMethod.setAttribute('mutiple', true);

            cancelBtn.addEventListener("click", () => cancelImage(imgContainer,cancelBtn));
        }
        reader.readAsDataURL(file);
    }
});
function cancelImage(imgContainer,cancelBtn) {
    let span = cancelBtn.nextElementSibling;
    let fileName = span.alt;
    files = Array.from(files);
    files = files.filter(f => f.name !== fileName);
    imgContainer.parentNode.removeChild(imgContainer);
    console.log(uplodaImageMethod);


}
