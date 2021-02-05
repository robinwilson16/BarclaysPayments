﻿var makePayment = document.getElementById('MakePayment');
if (makePayment) {
    makePayment.addEventListener('submit', function (event) {
        event.preventDefault();

        if ($("#MakePayment").valid() === true) {
            let sHAPassphrase = document.getElementById('SHAPassphrase').value;
            let formDestinationID = document.getElementById('FormDestinationID').value;

            let epdqItems = {};
            let epdqItemsEncrypt = "";

            //New way
            let formData = new FormData(makePayment);
            const formItems = Array.from(formData.entries());
            const sortedItems = formItems.sort(
                ([leftKey], [rightKey]) => leftKey > rightKey ? 1 : -1
            )

            for (let [key, value] of sortedItems) {
                //console.log(`${key}: ${value}`);
                //Remove BarclaysPayment. from start of each form item
                key = key.replace("BarclaysPayment.", "");
                let includeField = true;

                //Define form fields to ignore and not include
                if (key.indexOf("__RequestVerificationToken") > -1) {
                    includeField = false;
                }
                else if (key.indexOf("PaymentReason") > -1) {
                    includeField = false;
                }
                else if (key.indexOf("PaymentReasonOther") > -1) {
                    includeField = false;
                }
                else if (value.length == 0) {
                    includeField = false;
                }

                //Discard empty elements
                if (includeField === true) {
                    //If item is amount this must be multiplied by 100 as decimals are not allowed
                    if (key === "AMOUNT") {
                        value = value * 100;
                    }

                    let epdqItem = key + "=" + value;

                    //Add item to array and encrypted string
                    epdqItems[key] = value;
                    epdqItemsEncrypt += epdqItem + sHAPassphrase;
                }
            }

            //Old way
            //let formData = $('#MakePayment').serialize();
            //let formItems = formData.split("&");

            //formItems.sort();

            //for (let element of formItems) {
            //    let epdqItem = element.replace("BarclaysPayment.", "");
            //    epdqItem = epdqItem.replace(/%20/g, " ");
            //    epdqItem = epdqItem.replace(/%40/g, "@");
            //    let splitPos = epdqItem.indexOf("=");
            //    let epdqLen = epdqItem.length;
            //    let includeField = true;

            //    if (element.indexOf("__RequestVerificationToken") > -1) {
            //        includeField = false;
            //    }
            //    else if (element.indexOf("PaymentReason") > -1) {
            //        includeField = false;
            //    }
            //    else if (element.indexOf("PaymentReasonOther") > -1) {
            //        includeField = false;
            //    }

            //    //Discard empty elements
            //    if (splitPos < epdqLen - 1 && includeField === true) {
            //        let key = epdqItem.substring(0, splitPos);
            //        let value = epdqItem.substring(splitPos + 1, epdqLen);

            //        //If item is amount this must be multiplied by 100 as decimals are not allowed
            //        if (key === "AMOUNT") {
            //            value = value * 100;
            //            epdqItem = key + "=" + value;
            //        }

            //        epdqItems[key] = value;
            //        epdqItemsEncrypt += epdqItem + sHAPassphrase;
            //    }
            //}

            //For debugging
            //let createPayment = document.getElementById('MakePayment');
            //let epdqData = document.createElement("div");
            //epdqData.innerHTML = epdqItemsEncrypt;
            //createPayment.appendChild(epdqData);

            epdqItems["SHASIGN"] = sha256(epdqItemsEncrypt);
            postAndRedirect(formDestinationID, epdqItems);
        }
    })
}

function postAndRedirect(url, postData) {
    let postForm = document.createElement("form");
    postForm.method = "POST";
    postForm.action = url;   
    postForm.innerHTML = "";

    for (var key in postData) {
        if (postData.hasOwnProperty(key)) {
            postForm.innerHTML += "<input type='hidden' name='" + key + "' value='" + postData[key] + "'></input>";
        }
    }

    document.body.appendChild(postForm);

    postForm.submit();
}

var copyPaymentLinks = document.querySelectorAll('.CopyPaymentLink');
copyPaymentLinks.forEach(function (button) {
    button.addEventListener('click', function (event) {
        let url = document.querySelector(".PaymentURL").innerHTML;

        navigator.clipboard.writeText(url).then(function () {
            /* clipboard successfully set */
        }, function () {
            /* clipboard write failed */
        });
    });
});

var openPaymentLinks = document.querySelectorAll('.OpenPaymentLink');
openPaymentLinks.forEach(function (button) {
    button.addEventListener('click', function (event) {
        let url = document.querySelector(".PaymentURL").innerHTML;

        var win = window.open(url, '_blank');
        win.focus();
    });
});

/**
* Secure Hash Algorithm (SHA1)
* http://www.webtoolkit.info/
**/
function SHA1(msg) {
    function rotate_left(n, s) {
        var t4 = (n << s) | (n >>> (32 - s));
        return t4;
    };
    function lsb_hex(val) {
        var str = '';
        var i;
        var vh;
        var vl;
        for (i = 0; i <= 6; i += 2) {
            vh = (val >>> (i * 4 + 4)) & 0x0f;
            vl = (val >>> (i * 4)) & 0x0f;
            str += vh.toString(16) + vl.toString(16);
        }
        return str;
    };
    function cvt_hex(val) {
        var str = '';
        var i;
        var v;
        for (i = 7; i >= 0; i--) {
            v = (val >>> (i * 4)) & 0x0f;
            str += v.toString(16);
        }
        return str;
    };
    function Utf8Encode(string) {
        string = string.replace(/\r\n/g, '\n');
        var utftext = '';
        for (var n = 0; n < string.length; n++) {
            var c = string.charCodeAt(n);
            if (c < 128) {
                utftext += String.fromCharCode(c);
            }
            else if ((c > 127) && (c < 2048)) {
                utftext += String.fromCharCode((c >> 6) | 192);
                utftext += String.fromCharCode((c & 63) | 128);
            }
            else {
                utftext += String.fromCharCode((c >> 12) | 224);
                utftext += String.fromCharCode(((c >> 6) & 63) | 128);
                utftext += String.fromCharCode((c & 63) | 128);
            }
        }
        return utftext;
    };
    var blockstart;
    var i, j;
    var W = new Array(80);
    var H0 = 0x67452301;
    var H1 = 0xEFCDAB89;
    var H2 = 0x98BADCFE;
    var H3 = 0x10325476;
    var H4 = 0xC3D2E1F0;
    var A, B, C, D, E;
    var temp;
    msg = Utf8Encode(msg);
    var msg_len = msg.length;
    var word_array = new Array();
    for (i = 0; i < msg_len - 3; i += 4) {
        j = msg.charCodeAt(i) << 24 | msg.charCodeAt(i + 1) << 16 |
            msg.charCodeAt(i + 2) << 8 | msg.charCodeAt(i + 3);
        word_array.push(j);
    }
    switch (msg_len % 4) {
        case 0:
            i = 0x080000000;
            break;
        case 1:
            i = msg.charCodeAt(msg_len - 1) << 24 | 0x0800000;
            break;
        case 2:
            i = msg.charCodeAt(msg_len - 2) << 24 | msg.charCodeAt(msg_len - 1) << 16 | 0x08000;
            break;
        case 3:
            i = msg.charCodeAt(msg_len - 3) << 24 | msg.charCodeAt(msg_len - 2) << 16 | msg.charCodeAt(msg_len - 1) << 8 | 0x80;
            break;
    }
    word_array.push(i);
    while ((word_array.length % 16) != 14) word_array.push(0);
    word_array.push(msg_len >>> 29);
    word_array.push((msg_len << 3) & 0x0ffffffff);
    for (blockstart = 0; blockstart < word_array.length; blockstart += 16) {
        for (i = 0; i < 16; i++) W[i] = word_array[blockstart + i];
        for (i = 16; i <= 79; i++) W[i] = rotate_left(W[i - 3] ^ W[i - 8] ^ W[i - 14] ^ W[i - 16], 1);
        A = H0;
        B = H1;
        C = H2;
        D = H3;
        E = H4;
        for (i = 0; i <= 19; i++) {
            temp = (rotate_left(A, 5) + ((B & C) | (~B & D)) + E + W[i] + 0x5A827999) & 0x0ffffffff;
            E = D;
            D = C;
            C = rotate_left(B, 30);
            B = A;
            A = temp;
        }
        for (i = 20; i <= 39; i++) {
            temp = (rotate_left(A, 5) + (B ^ C ^ D) + E + W[i] + 0x6ED9EBA1) & 0x0ffffffff;
            E = D;
            D = C;
            C = rotate_left(B, 30);
            B = A;
            A = temp;
        }
        for (i = 40; i <= 59; i++) {
            temp = (rotate_left(A, 5) + ((B & C) | (B & D) | (C & D)) + E + W[i] + 0x8F1BBCDC) & 0x0ffffffff;
            E = D;
            D = C;
            C = rotate_left(B, 30);
            B = A;
            A = temp;
        }
        for (i = 60; i <= 79; i++) {
            temp = (rotate_left(A, 5) + (B ^ C ^ D) + E + W[i] + 0xCA62C1D6) & 0x0ffffffff;
            E = D;
            D = C;
            C = rotate_left(B, 30);
            B = A;
            A = temp;
        }
        H0 = (H0 + A) & 0x0ffffffff;
        H1 = (H1 + B) & 0x0ffffffff;
        H2 = (H2 + C) & 0x0ffffffff;
        H3 = (H3 + D) & 0x0ffffffff;
        H4 = (H4 + E) & 0x0ffffffff;
    }
    var temp = cvt_hex(H0) + cvt_hex(H1) + cvt_hex(H2) + cvt_hex(H3) + cvt_hex(H4);

    return temp.toLowerCase();
}

function sha256(ascii) {
    function rightRotate(value, amount) {
        return (value >>> amount) | (value << (32 - amount));
    };

    var mathPow = Math.pow;
    var maxWord = mathPow(2, 32);
    var lengthProperty = 'length'
    var i, j; // Used as a counter across the whole file
    var result = ''

    var words = [];
    var asciiBitLength = ascii[lengthProperty] * 8;

    //* caching results is optional - remove/add slash from front of this line to toggle
    // Initial hash value: first 32 bits of the fractional parts of the square roots of the first 8 primes
    // (we actually calculate the first 64, but extra values are just ignored)
    var hash = sha256.h = sha256.h || [];
    // Round constants: first 32 bits of the fractional parts of the cube roots of the first 64 primes
    var k = sha256.k = sha256.k || [];
    var primeCounter = k[lengthProperty];
    /*/
    var hash = [], k = [];
    var primeCounter = 0;
    //*/

    var isComposite = {};
    for (var candidate = 2; primeCounter < 64; candidate++) {
        if (!isComposite[candidate]) {
            for (i = 0; i < 313; i += candidate) {
                isComposite[i] = candidate;
            }
            hash[primeCounter] = (mathPow(candidate, .5) * maxWord) | 0;
            k[primeCounter++] = (mathPow(candidate, 1 / 3) * maxWord) | 0;
        }
    }

    ascii += '\x80' // Append Ƈ' bit (plus zero padding)
    while (ascii[lengthProperty] % 64 - 56) ascii += '\x00' // More zero padding
    for (i = 0; i < ascii[lengthProperty]; i++) {
        j = ascii.charCodeAt(i);
        if (j >> 8) return; // ASCII check: only accept characters in range 0-255
        words[i >> 2] |= j << ((3 - i) % 4) * 8;
    }
    words[words[lengthProperty]] = ((asciiBitLength / maxWord) | 0);
    words[words[lengthProperty]] = (asciiBitLength)

    // process each chunk
    for (j = 0; j < words[lengthProperty];) {
        var w = words.slice(j, j += 16); // The message is expanded into 64 words as part of the iteration
        var oldHash = hash;
        // This is now the undefinedworking hash", often labelled as variables a...g
        // (we have to truncate as well, otherwise extra entries at the end accumulate
        hash = hash.slice(0, 8);

        for (i = 0; i < 64; i++) {
            var i2 = i + j;
            // Expand the message into 64 words
            // Used below if 
            var w15 = w[i - 15], w2 = w[i - 2];

            // Iterate
            var a = hash[0], e = hash[4];
            var temp1 = hash[7]
                + (rightRotate(e, 6) ^ rightRotate(e, 11) ^ rightRotate(e, 25)) // S1
                + ((e & hash[5]) ^ ((~e) & hash[6])) // ch
                + k[i]
                // Expand the message schedule if needed
                + (w[i] = (i < 16) ? w[i] : (
                    w[i - 16]
                    + (rightRotate(w15, 7) ^ rightRotate(w15, 18) ^ (w15 >>> 3)) // s0
                    + w[i - 7]
                    + (rightRotate(w2, 17) ^ rightRotate(w2, 19) ^ (w2 >>> 10)) // s1
                ) | 0
                );
            // This is only used once, so *could* be moved below, but it only saves 4 bytes and makes things unreadble
            var temp2 = (rightRotate(a, 2) ^ rightRotate(a, 13) ^ rightRotate(a, 22)) // S0
                + ((a & hash[1]) ^ (a & hash[2]) ^ (hash[1] & hash[2])); // maj

            hash = [(temp1 + temp2) | 0].concat(hash); // We don't bother trimming off the extra ones, they're harmless as long as we're truncating when we do the slice()
            hash[4] = (hash[4] + temp1) | 0;
        }

        for (i = 0; i < 8; i++) {
            hash[i] = (hash[i] + oldHash[i]) | 0;
        }
    }

    for (i = 0; i < 8; i++) {
        for (j = 3; j + 1; j--) {
            var b = (hash[i] >> (j * 8)) & 255;
            result += ((b < 16) ? 0 : '') + b.toString(16);
        }
    }
    return result;
};