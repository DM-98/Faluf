function setCodeFromGist() {
    loadIframe();

    var message = {
        type: "setWorkspaceFromGist",
        gistId: "e65f274997f6ae405d4b76a2db9117b1",
        bufferId: "test.cs"
    };

    postMessageToEditor(message);
}

function postMessageToEditor(message) {
    document.getElementById('example-iframe').contentWindow.postMessage(message, "https://localhost:7249");
}

function loadIframe() {
    var iframe = document.querySelector('#dotnet-try');
    var meta = document.querySelector('meta[http-equiv=\'Content-Security-Policy\']');

    if (iframe && meta) {
        iframe.setAttribute('src', 'https://try.dot.net/?fromGist=df44833326fcc575e8169fccb9d41fc7');
        iframe.setAttribute('content', 'frame-ancestors \'self\' https://try.dot.net/');
    }
}