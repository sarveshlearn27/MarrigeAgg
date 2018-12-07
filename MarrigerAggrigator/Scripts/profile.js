//Fill Values in Age
var age = [];
for (i = 20; i < 60; i++) {
    age.push(i);
}
var sel = document.getElementById('ageValues');
var sel2 = document.getElementById('ageValues2');
for (val = 0; val < age.length; val++) {
    var opt = document.createElement('option');
    opt.innerHTML = age[val];
    opt.value = age[val];
    sel.appendChild(opt);
}

for (val = 0; val < age.length; val++) {
    var opt = document.createElement('option');
    opt.innerHTML = age[val];
    opt.value = age[val];
    sel2.appendChild(opt);
}

//Fill Religion Values
var religion = ["Hindu", "Muslim", "Christian", "Sikh", "Parsi", "Jain", "Buddhist", "Jewish", "No Religion", "Spritiual", "Other"];
var religionSelect = document.getElementById('religion');
for (val = 0; val < religion.length; val++) {
    var opt = document.createElement('option');
    opt.innerHTML = religion[val];
    opt.value = religion[val];
    religionSelect.appendChild(opt);
}

//Fill Mother tounge

var mothertounge = ["Hindi", "Bengali", "Tamil", "Telugu", "English", "Punjabi", "Kannada", "Gujarati", "Urdu", "Sanskrit", "Maithili"];
var mothertoungeSelect = document.getElementById('mothertounge');
for (val = 0; val < mothertounge.length; val++) {
    var opt = document.createElement('option');
    opt.innerHTML = religion[val];
    opt.value = religion[val];
    mothertoungeSelect.appendChild(opt);
}
