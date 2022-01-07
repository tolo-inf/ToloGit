import { Nagrada } from "./Nagrada.js";
import { Igra } from "./Igra.js";

export class Sajt{

    constructor(listaIgara){
        this.listaIgara = listaIgara;
        this.kontejner = null;
    }
    
    crtaj(host)
    {
        this.kontejner=document.createElement("div");
        this.kontejner.className="GlavniKontejner";
        host.appendChild(this.kontejner);

        let kontForma1 = document.createElement("div");
        kontForma1.className="Forma1";
        this.kontejner.appendChild(kontForma1);

        /*let kontForma2 = document.createElement("div");
        kontForma2.className="Forma2";
        this.kontejner.appendChild(kontForma2);

        let kontForma3 = document.createElement("div");
        kontForma3.className="Forma3";
        this.kontejner.appendChild(kontForma3);*/

        let kontIgra = document.createElement("div");
        kontIgra.className="Igra";
        this.kontejner.appendChild(kontIgra);

        /*let kontKorpa = document.createElement("div");
        kontKorpa.className="Korpa";
        this.kontejner.appendChild(kontKorpa);

        let kontNagrada = document.createElement("div");
        kontNagrada.className="Nagrada";
        this.kontejner.appendChild(kontNagrada);

        let kontSlika = document.createElement("div");
        kontSlika.className="Slika";
        this.kontejner.appendChild(kontSlika);*/


        this.crtajFormu1(kontForma1);
        //this.crtajFormu2(kontForma2);
        //this.crtajFormu3(kontForma3);
        this.crtajIgru(kontIgra);
        //this.crtajKorpu(kontKorpa);
        //this.crtajNagradu(kontNagrada);
        //this.crtajSliku(kontSlika);
    }

    crtajFormu1(host)
    {
        let red = this.crtajRed(host);

        let l = document.createElement("label");
        l.innerHTML="Username:";
        red.appendChild(l);

        let usernamePolje = document.createElement("input");
        usernamePolje.type = "text";
        red.appendChild(usernamePolje);

        let btnRegistrujSe = document.createElement("button");
        btnRegistrujSe.innerHTML="Registruj se";
        btnRegistrujSe.onclick=(ev)=>this.upisiKorisnika(usernamePolje.value);
        red.appendChild(btnRegistrujSe);

        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML = "Dodaj ocenu"
        red.appendChild(l);

        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML = "Igra:"
        red.appendChild(l);

        let igraSelect = document.createElement("select");
        red.appendChild(igraSelect);

        let opcija;
        this.listaIgara.forEach(p => {
            opcija = document.createElement("option");
            opcija.innerHTML = p.naziv;
            opcija.value = p.id;
            igraSelect.appendChild(opcija);
        })

        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML = "Gameplay:"
        red.appendChild(l);
        let gameplayPolje = document.createElement("input");
        gameplayPolje.type = "number";
        red.appendChild(gameplayPolje);

        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML = "Story:"
        red.appendChild(l);
        let storyPolje = document.createElement("input");
        storyPolje.type = "number";
        red.appendChild(storyPolje);

        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML = "Music:"
        red.appendChild(l);
        let musicPolje = document.createElement("input");
        musicPolje.type = "number";
        red.appendChild(musicPolje);

        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML = "Graphics:"
        red.appendChild(l);
        let graphicsPolje = document.createElement("input");
        graphicsPolje.type = "number";
        red.appendChild(graphicsPolje);

        red = this.crtajRed(host);
        let btnDodajOcenu = document.createElement("button");
        btnDodajOcenu.innerHTML="Dodaj";
        btnDodajOcenu.onclick=(ev)=>this.upisiOcenu(gameplayPolje.value,storyPolje.value,musicPolje.value,graphicsPolje.value);
        red.appendChild(btnDodajOcenu);

        let btnObrisiOcenu = document.createElement("button");
        btnObrisiOcenu.innerHTML = "Obrisi";
        btnObrisiOcenu.onclick=(ev)=>this.obrisiOcenu();
        red.appendChild(btnObrisiOcenu);

        let btnNagrade = document.createElement("button");
        btnNagrade.innerHTML = "Nagrade";
        btnNagrade.onclick=(ev)=>this.prikaziNagrade();
        red.appendChild(btnNagrade);

        //-----------------------------------------------------------
        /*let se = document.createElement("select");
        red.appendChild(se);

        let op;
        this.listaPredmeta.forEach(p=>{
            op = document.createElement("option");
            op.innerHTML=p.naziv;
            op.value=p.id;
            se.appendChild(op);
        })

        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML="Rok";
        red.appendChild(l);

        let cbbox = document.createElement("div");
        cbbox.className="cbbox";
        red.appendChild(cbbox);

        let cbboxLevi = document.createElement("div");
        cbboxLevi.className="cbboxLevi";
        cbbox.appendChild(cbboxLevi);

        let cbboxDesni = document.createElement("div");
        cbboxDesni.className="cbboxDesni";
        cbbox.appendChild(cbboxDesni);

        let cb;
        let cbDiv;
        this.listaRokova.forEach((r,index)=>{
            cbDiv = document.createElement("div");
            cb= document.createElement("input");
            cb.type="checkbox";
            cb.value=r.id;
            cbDiv.appendChild(cb);

            l =  document.createElement("label");
            l.innerHTML=r.naziv;
            cbDiv.appendChild(l);

            if(index%2==0){
                cbboxLevi.appendChild(cbDiv);
            }
            else{
                cbboxDesni.appendChild(cbDiv);
            }
        })

        red = this.crtajRed(host);
        let btnNadji = document.createElement("button");
        btnNadji.onclick=(ev)=>this.nadjiStudente();
        btnNadji.innerHTML="Nadji";
        red.appendChild(btnNadji);


        red = this.crtajRed(host);
        l =  document.createElement("label");
            l.innerHTML="Indeks"
            red.appendChild(l);
        var brojIndeksa = document.createElement("input");
        brojIndeksa.type="number";
        brojIndeksa.className="BrojIndeksa";
        red.appendChild(brojIndeksa);


        red = this.crtajRed(host);
        l =  document.createElement("label");
        l.innerHTML="Ocena"
        red.appendChild(l);
        var poljeOcena = document.createElement("input");
        poljeOcena.type="number";
        poljeOcena.className="Ocena";
        red.appendChild(poljeOcena);

        red = this.crtajRed(host);
        let btnUpisi = document.createElement("button");
        btnUpisi.onclick=(ev)=>this.upisi(brojIndeksa.value,poljeOcena.value);
        btnUpisi.innerHTML="Upisi";
        red.appendChild(btnUpisi);*/
        //---------------------------------------------------------------------------
    }

    crtajFormu2(host)
    {

    }

    crtajFormu3(host)
    {

    }

    crtajIgru(host)
    {
        var tabela = document.createElement("table");
        tabela.className="tabela";
        host.appendChild(tabela);

        var tabelahead= document.createElement("thead");
        tabela.appendChild(tabelahead);

        var tr = document.createElement("tr");
        tabelahead.appendChild(tr);

        var tabelaBody = document.createElement("tbody");
        tabelaBody.className="TabelaPodaci";
        tabela.appendChild(tabelaBody);

        let th;
        var zag=["Naziv", "Zanr", "Godina Izlaska", "Developer", "Publisher", "Ocena"];
        zag.forEach(el=>{
            th = document.createElement("th");
            th.innerHTML=el;
            tr.appendChild(th);
        })
    }

    crtajKorpu(host)
    {

    }

    crtajNagradu(host)
    {

    }

    crtajSliku()
    {

    }

    crtajRed(host)
    {
        let red = document.createElement("div");
        red.className="red";
        host.appendChild(red);
        return red;
    }

    upisiKorisnika(username)
    {
        if(username == "" || username == null)
        {
            alert("Unesite korisnicko ime!");
            return;
        }

        console.log(username);
        fetch("https://localhost:5001/Korisnik/DodajKorisnika/"+username,
        {
            method:"POST"
        })
        .then
        {
            alert("Uspesno upisan novi korisnik!");
        }
    }

    upisiOcenu(gameplay,story,music,graphics)
    {
        if(gameplay === ""){
            alert("Unesite ocenu za gameplay");
            return;
        }
        if(story === ""){
            alert("Unesite ocenu za story");
            return;
        }
        if(music === ""){
            alert("Unesite ocenu za music");
            return;
        }
        if(graphics === ""){
            alert("Unesite ocenu za graphics");
            return;
        }

        let gameplayPars = parseInt(gameplay);
        let storyPars = parseInt(story);
        let musicPars = parseInt(music);
        let graphicsPars = parseInt(graphics);

        if(gameplayPars < 1 || gameplayPars > 5)
        {
            alert("Unesite vrednost izmedju 1 i 5");
            return;
        }
        if(storyPars < 1 || storyPars > 5)
        {
            alert("Unesite vrednost izmedju 1 i 5");
            return;
        }
        if(musicPars < 1 || musicPars > 5)
        {
            alert("Unesite vrednost izmedju 1 i 5");
            return;
        }
        if(graphicsPars < 1 || graphicsPars > 5)
        {
            alert("Unesite vrednost izmedju 1 i 5");
            return;
        }
        
        let igraOptionEl = this.kontejner.querySelector("select");
        var idIgre = igraOptionEl.options[igraOptionEl.selectedIndex].value;
        let usernameEl = this.kontejner.querySelector("input[type='text']");
        var usernameKorisnika = usernameEl.value;
        //console.log(idIgre);
        //console.log(usernameKorisnika);

        fetch("https://localhost:5001/Ocena/DodajOcenu/"+gameplay+"/"+story+"/"+music+"/"+graphics+"/"+idIgre+"/"+usernameKorisnika,
        {
            method:"POST"
        }).then( s=>
            {
                //console.log(s.status);
                //console.log(s);
               if (s.status == 200)
               {
                   var teloTabele = this.obrisiPrethodniSadrzaj();
                   s.json().then(s=>
                    {
                           const i = new Igra(s.id, s.naziv, s.zanr, s.godinaIzlaska, s.developer, s.publisher);
                           i.crtaj(teloTabele);
                    });
                   
               }
            })

    }

    obrisiOcenu()
    {
        let igraOptionEl2 = this.kontejner.querySelector("select");
        var idIgre2 = igraOptionEl2.options[igraOptionEl2.selectedIndex].value;
        let usernameEl2 = this.kontejner.querySelector("input[type='text']");
        var usernameKorisnika2 = usernameEl2.value;

        fetch("https://localhost:5001/Ocena/ObrisiOcenu/"+idIgre2+"/"+usernameKorisnika2,
        {
            method:"DELETE"
        }).then
        {
            alert("Uspesno obrisana ocena");
        }
    }

    obrisiPrethodniSadrzaj()
    {
        var teloTabele = document.querySelector(".TabelaPodaci");
        var roditelj = teloTabele.parentNode;
        roditelj.removeChild(teloTabele);

        teloTabele = document.createElement("tbody");
        teloTabele.className="TabelaPodaci";
        roditelj.appendChild(teloTabele);
        return teloTabele;
    }

    prikaziNagrade()
    {
        let igraOptionEl3 = this.kontejner.querySelector("select");
        var idIgre3 = igraOptionEl3.options[igraOptionEl3.selectedIndex].value;

        fetch("https://localhost:5001/Nagrada/PreuzmiNagrade/"+idIgre3,
        {
            method:"GET"
        }).then( s=>
            {
                //console.log(s.status);
                //console.log(s);
               if (s.status == 200)
               {
                   var teloTabele = this.obrisiPrethodniSadrzaj();
                   s.json().then(data=>{
                       //console.log(data);
                       data.forEach(s=>{
                           const n = new Nagrada(s.id, s.nazivOrg, s.kategorija, s.igraFK);
                           n.crtaj(teloTabele);
                       });
                   })
               }
            })
    }

}