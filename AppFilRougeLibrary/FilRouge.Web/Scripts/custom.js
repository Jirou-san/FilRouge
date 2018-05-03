//TO DO
// Quand on supprime une réponse mettre a jour currentNbReponse


$("#to_clone").hide();//cache la div reponse

const max = 4; //max de réponses
const maxTrue = max-1; //max de bonne réponses

var section_reponse = $(".section_reponse");//selecteur section reponse
let allCheked = section_reponse.find("input:checked");//toute les checkbox isTrue de la section reponse
var nbChecked = allCheked.length; //nb de checkbox isTrue a l'initialisation du Dom
var currentNbChecked = nbChecked; //nb de checkbox isTrue a l'instant T

var reponse_checkbox = $(section_reponse).find('input:checkbox');

//action "ajouter une réponse"
$("#add").click(function (event) {
    event.preventDefault();
    //quand ajout: si nb reponses n'est pas atteint > clone le div reponse + rafraichit le nb réponses
    //sinon > aucune action
    if (nbReponse < max) {
        $("#to_clone").clone().appendTo(section_reponse).removeAttr("id").show();
        nbReponse++;
    }
});

//Action > Suppression d'une reponse
section_reponse.on('click', 'button', function () {
    //rafraichit le nb de reponses
    nbReponse--;

    //supprime la div reponse
    $(this).closest(".form-group").remove();

    //si la checkbox a supprimer de section_reponse.form-group est coché (bonne reponse) >  rafraichit compteur nb bonne reponse
    if ($(this).closest(".form-group").find(":checkbox").is(':checked')) {
        currentNbChecked--;
    }

    //rafraichit le verrouillage des checkbox (si nb bonne réponse = max bonne reponse)
    checkboxLocker(currentNbChecked, maxTrue, $('input:checkbox'));
});

//colore le champ en fonction de sa validité (bonne/mauvaise réponse)
section_reponse.on('change', ':checkbox', function () {

    //si checkbox isTrue coché = bonne réponse > border green
    if ($(this).prop("checked")) {
        $(this).closest(".form-group").find(".form-control").css("border-color", "green");
        currentNbChecked++;
    }
    //si fausse réponse > border red
    else {
        $(this).closest(".form-group").find(".form-control").css("border-color", "red");
        currentNbChecked--;
    }
    //rafraichit le verrouillage des checkbox (si nb bonne réponse = max bonne reponse)
    checkboxLocker(currentNbChecked, maxTrue, $('input:checkbox'));
});

//desactive les checkbox en fonction du nombre de checkbox valid et nb max.
function checkboxLocker(nbItemChecked, maxChecked, selector) {
    if (nbItemChecked == maxChecked) {
        $(selector).not(':checked').prop('disabled', true);
    }
    else {
        $(selector).not(':checked').prop('disabled', false);
    }
}

//colorise un champs text selon si la checkbox est coché 
function inputTextColorizer(checkbox, area, toColorize) {
    $(checkbox).each(function () {

        if (this.checked == true) {
            $(this).closest(area).find(toColorize).css("border-color", "green");
        }
        else {
            $(this).closest(area).find(toColorize).css("border-color", "red");
        }
    });
}

//initialisation de "section_reponse"
section_reponse.ready(function () {

    checkboxLocker(currentNbChecked, maxTrue, $('input:checkbox'));
    inputTextColorizer(reponse_checkbox, ".form-group", ".form-control");
    
});


$("#alert").delay(1800).slideUp(300);


