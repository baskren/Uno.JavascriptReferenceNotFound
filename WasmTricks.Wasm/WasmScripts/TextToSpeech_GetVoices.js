function GetVoicesPromise() {
    return new Promise(
        function (resolve, reject) {
            if ('speechSynthesis' in window) {
                let synth = window.speechSynthesis;
                let id;

                id = setInterval(() => {
                    if (synth.getVoices().length !== 0) {
                        resolve(GetVoices());
                        clearInterval(id);
                    }
                }, 10);
            }
            else
                resolve('NOT_AVAILABLE');
        }
    );
}

function GetVoices() {
    if (typeof speechSynthesis === 'undefined') {
        return 'NONE';
    }
    var result = '';
    var voices = speechSynthesis.getVoices();

    for (var i = 0; i < voices.length; i++) {
        result += voices[i].name + ':' + voices[i].lang;
        if (voices[i].default)
            result += '-DEFAULT';
        result += ';';
    }
    return result;
}
function UnoTextToSpeech_PerformSpeekPromise() {

}