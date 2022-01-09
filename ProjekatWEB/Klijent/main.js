import { Sajt } from "./Sajt.js";
import { Igra } from "./Igra.js";

var listaIgara =[];

fetch("https://localhost:5001/Igra/PreuzmiIgre")
.then(p=>{
    p.json().then(igre=>{
        igre.forEach(igra => {
            var p = new Igra(igra.id, igra.naziv, igra.zanr, igra.godinaIzlaska, igra.developer, igra.publisher);
            listaIgara.push(p);
        })

        var s = new Sajt("Steam",listaIgara);
        s.crtaj(document.body);
        
        var s2 = new Sajt("Epic",listaIgara);
        s2.crtaj(document.body);
    })
})
console.log(listaIgara);

