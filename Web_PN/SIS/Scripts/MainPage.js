function CopyText() {

    var cb = document.getElementById('MainContent_chkSameascurrent');



    var txtAddress = document.getElementById('MainContent_txtAddress');
    var txtVillage = document.getElementById('MainContent_txtVillage');
    var cmbcity = document.getElementById('MainContent_cmbcity');
    var cmbDistrict = document.getElementById('MainContent_cmbDistrict');
    var cmbstate = document.getElementById('MainContent_cmbstate');
    var cmbcountry = document.getElementById('MainContent_cmbcountry');
    var txtPin = document.getElementById('MainContent_txtPin');

    var txtPermanentAddress = document.getElementById('MainContent_txtPermanentAddress');
    var txtPVillage = document.getElementById('MainContent_txtPVillage');
    var cmbPCity = document.getElementById('MainContent_cmbPCity');
    var cmbPDistrict = document.getElementById('MainContent_cmbPDistrict');
    var cmbpstate = document.getElementById('MainContent_cmbpstate');
    var cmbPCountry = document.getElementById('MainContent_cmbPCountry');
    var txtPPin = document.getElementById('MainContent_txtPPin');

    if (cb.checked) {

        txtPermanentAddress.value = txtAddress.value;
        txtPVillage.value = txtVillage.value;
        cmbPCity.value = cmbcity.value;
        cmbPDistrict.value = cmbDistrict.value;
        cmbpstate.value = cmbstate.value;
        cmbPCountry.value = cmbcountry.value;
        txtPPin.value = txtPin.value;

    }

    txtPermanentAddress.disabled = cb.checked;
    txtPVillage.disabled = cb.checked;
    cmbPCity.disabled = cb.checked;
    cmbPDistrict.disabled = cb.checked;
    cmbpstate.disabled = cb.checked;
    cmbPCountry.disabled = cb.checked;
    txtPPin.disabled = cb.checked;

}



function ForeginCountrySpan(Country) {

    var distcityspan = document.getElementById("MainContent_distcityspan");
    var lblVillage = document.getElementById("MainContent_lblVillage");
   
    if (Country.options[Country.selectedIndex].text != "India") {
        distcityspan.style.display = "none";
        lblVillage.innerHTML = 'City';
    }
    else {
        distcityspan.style.display = "block";
        lblVillage.innerHTML = 'Village';
    }
}


function ForeginPCountrySpan(Country) {

    var Pdistrictcity = document.getElementById("MainContent_Pdistrictcity");
    var lblPVillage = document.getElementById("MainContent_lblPVillage");
    if (Country.options[Country.selectedIndex].text != "India") {
        Pdistrictcity.style.display = "none";
        lblPVillage.innerHTML = 'City';
    }
    else {
        Pdistrictcity.style.display = "block";
        lblPVillage.innerHTML = 'Village';
    }
}


function ForeginOCountrySpan(Country) {

    var Odistrictcity = document.getElementById("MainContent_Odistrictcity");
    var lblOVillage = document.getElementById("MainContent_lblOVillage");
    if (Country.options[Country.selectedIndex].text != "India") {
        Odistrictcity.style.display = "none";
        lblOVillage.innerHTML = 'City';
    }
    else {
        Odistrictcity.style.display = "block";
        lblOVillage.innerHTML = 'Village';
    }
}