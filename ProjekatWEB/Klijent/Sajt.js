import { Nagrada } from "./Nagrada.js";
import { Igra } from "./Igra.js";
import { Prodavnica } from "./Prodavnica.js";

export class Sajt{

    constructor(naziv,listaIgara){
        this.naziv = naziv;
        this.listaIgara = listaIgara;
        this.kontejner = null;
    }
    
    crtaj(host)
    {
        this.kontejner = document.createElement("div");
        this.kontejner.className = "NajvisiKontejner";
        host.appendChild(this.kontejner);

        let kontNaslov = document.createElement("div");
        kontNaslov.className = "PomocniKontejner";
        this.kontejner.appendChild(kontNaslov);
        
        let kontGlavni = document.createElement("div");
        kontGlavni.className="GlavniKontejner";
        this.kontejner.appendChild(kontGlavni);

        let kontPomocni1 = document.createElement("div");
        kontPomocni1.className = "PomocniKontejner";
        kontGlavni.appendChild(kontPomocni1);

        let kontPomocni2 = document.createElement("div");
        kontPomocni2.className = "PomocniKontejner";
        kontGlavni.appendChild(kontPomocni2);

        let kontForma1 = document.createElement("div");
        kontForma1.className="Forma1";
        kontPomocni1.appendChild(kontForma1);

        let kontForma2 = document.createElement("div");
        kontForma2.className="Forma2";
        kontPomocni1.appendChild(kontForma2);
        
        let kontKorpa = document.createElement("div");
        kontKorpa.className="Korpa";
        kontPomocni1.appendChild(kontKorpa);

        let kontIgra = document.createElement("div");
        kontIgra.className="Igra";
        kontPomocni2.appendChild(kontIgra);

        let kontNagrada = document.createElement("div");
        kontNagrada.className="Nagrada";
        kontPomocni2.appendChild(kontNagrada);

        let kontForma3 = document.createElement("div");
        kontForma3.className="Forma3";
        kontPomocni2.appendChild(kontForma3);

        let kontSlika = document.createElement("div");
        kontSlika.className="Slika";
        kontPomocni2.appendChild(kontSlika);


        this.crtajNaslov(kontNaslov);
        this.crtajFormu1(kontForma1);
        this.crtajFormu2(kontForma2);
        this.crtajFormu3(kontForma3);
        this.crtajIgru(kontIgra);
        this.crtajKorpu(kontKorpa);
        this.crtajNagradu(kontNagrada);
        this.crtajSliku(kontSlika);
    }

    crtajNaslov(host)
    {
        let red = this.crtajRed(host);

        let l = document.createElement("h1");
        l.innerHTML = this.naziv;
        red.appendChild(l);
    }

    crtajFormu1(host)
    {
        let red = this.crtajRed(host);

        let l = document.createElement("label");
        l.innerHTML="Username:";
        red.appendChild(l);

        let usernamePolje = document.createElement("input");
        usernamePolje.className = "Polje";
        usernamePolje.type = "text";
        red.appendChild(usernamePolje);

        let btnRegistrujSe = document.createElement("button");
        btnRegistrujSe.className = "Dugme";
        btnRegistrujSe.innerHTML="Registruj se";
        btnRegistrujSe.onclick=(ev)=>this.upisiKorisnika(usernamePolje.value);
        red.appendChild(btnRegistrujSe);

        red = this.crtajRed(host);
        l = document.createElement("h2");
        l.innerHTML = "Oceni";
        red.appendChild(l);

        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML = "Igra:";
        red.appendChild(l);

        let igraSelect = document.createElement("select");
        igraSelect.className = "Polje";
        igraSelect.id = "selectOcena";
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
        l.innerHTML = "Gameplay:";
        red.appendChild(l);
        let gameplayPolje = document.createElement("input");
        gameplayPolje.className = "Polje";
        gameplayPolje.type = "number";
        red.appendChild(gameplayPolje);

        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML = "Story:";
        red.appendChild(l);
        let storyPolje = document.createElement("input");
        storyPolje.className = "Polje";
        storyPolje.type = "number";
        red.appendChild(storyPolje);

        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML = "Music:";
        red.appendChild(l);
        let musicPolje = document.createElement("input");
        musicPolje.className = "Polje";
        musicPolje.type = "number";
        red.appendChild(musicPolje);

        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML = "Graphics:";
        red.appendChild(l);
        let graphicsPolje = document.createElement("input");
        graphicsPolje.className = "Polje";
        graphicsPolje.type = "number";
        red.appendChild(graphicsPolje);

        red = this.crtajRed(host);
        let btnDodajOcenu = document.createElement("button");
        btnDodajOcenu.className = "Dugme";
        btnDodajOcenu.innerHTML="Dodaj";
        btnDodajOcenu.onclick=(ev)=>this.upisiOcenu(gameplayPolje.value,storyPolje.value,musicPolje.value,graphicsPolje.value);
        red.appendChild(btnDodajOcenu);

        let btnObrisiOcenu = document.createElement("button");
        btnObrisiOcenu.className = "Dugme";
        btnObrisiOcenu.innerHTML = "Obrisi";
        btnObrisiOcenu.onclick=(ev)=>this.obrisiOcenu();
        red.appendChild(btnObrisiOcenu);

        let btnNagrade = document.createElement("button");
        btnNagrade.className = "Dugme";
        btnNagrade.innerHTML = "Nagrade";
        btnNagrade.onclick=(ev)=>this.prikaziNagrade();
        red.appendChild(btnNagrade);

    }

    crtajFormu2(host)
    {
        let red = this.crtajRed(host);

        let l = document.createElement("h2");
        l.innerHTML = "Prodavnica";
        red.appendChild(l);

        red = this.crtajRed(host);
        
        l = document.createElement("label");
        l.innerHTML = "Igra:";
        red.appendChild(l);

        let igraSelect = document.createElement("select")
        igraSelect.className = "Polje";
        igraSelect.id = "selectProdavnica";
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
        l.innerHTML = "Kolicina:"
        red.appendChild(l);

        let kolicinaPolje = document.createElement("input");
        kolicinaPolje.className = "Polje";
        kolicinaPolje.type = "number";
        red.appendChild(kolicinaPolje);

        let btnDodajUKorpu = document.createElement("button");
        btnDodajUKorpu.className = "Dugme";
        btnDodajUKorpu.innerHTML = "Dodaj u korpu";
        btnDodajUKorpu.onclick=(ev)=>this.dodajUKorpu(kolicinaPolje.value);
        red.appendChild(btnDodajUKorpu);

        let btnKupi = document.createElement("button");
        btnKupi.className = "Dugme";
        btnKupi.innerHTML = "Kupi";
        btnKupi.onclick=(ev)=>this.obaviKupovinu(kolicinaPolje.value);
        red.appendChild(btnKupi);

    }

    crtajFormu3(host)
    {
        let red = this.crtajRed(host);

        let l = document.createElement("h2");
        l.innerHTML = "Prikazi omot";
        red.appendChild(l);

        red = this.crtajRed(host);
        
        l = document.createElement("label");
        l.innerHTML = "Igra:";
        red.appendChild(l);

        let igraSelect = document.createElement("select")
        igraSelect.className = "Polje";
        igraSelect.id = "selectSlika";
        red.appendChild(igraSelect);

        let opcija;
        this.listaIgara.forEach(p => {
            opcija = document.createElement("option");
            opcija.innerHTML = p.naziv;
            opcija.value = p.id;
            igraSelect.appendChild(opcija);
        })

        let btnPrikazi = document.createElement("button");
        btnPrikazi.className = "Dugme";
        btnPrikazi.innerHTML = "Prikazi";
        btnPrikazi.onclick=(ev)=>this.prikaziSliku();
        red.appendChild(btnPrikazi);

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
        tabelaBody.className="TabelaPodaciIgra";
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
        var tabela = document.createElement("table");
        host.appendChild(tabela);

        var tabelahead= document.createElement("thead");
        tabela.appendChild(tabelahead);

        var tr = document.createElement("tr");
        tabelahead.appendChild(tr);

        var tabelaBody = document.createElement("tbody");
        tabelaBody.className="TabelaPodaciKorpa";
        tabela.appendChild(tabelaBody);

        let th;
        var zag=["Igra", "Cena", "Kolicina", "Racun"];
        zag.forEach(el=>{
            th = document.createElement("th");
            th.innerHTML=el;
            tr.appendChild(th);
        })
    }

    crtajNagradu(host)
    {
        var tabela = document.createElement("table");
        tabela.className="tabela";
        host.appendChild(tabela);

        var tabelahead= document.createElement("thead");
        tabela.appendChild(tabelahead);

        var tr = document.createElement("tr");
        tabelahead.appendChild(tr);

        var tabelaBody = document.createElement("tbody");
        tabelaBody.className="TabelaPodaciNagrada";
        tabela.appendChild(tabelaBody);

        let th;
        var zag=["Naziv Organizacije", "Kategorija"];
        zag.forEach(el=>{
            th = document.createElement("th");
            th.innerHTML=el;
            tr.appendChild(th);
        })
    }

    crtajSliku(host)
    {
        var slika = document.createElement("img");
        slika.className = "SlikaZaPrikaz";
        slika.id = "slikaZaPrikaz";
        host.appendChild(slika);
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
        
        let igraOptionEl = this.kontejner.querySelector("select[id='selectOcena']");
        var idIgre = igraOptionEl.options[igraOptionEl.selectedIndex].value;
        let usernameEl = this.kontejner.querySelector("input[type='text']");
        var usernameKorisnika = usernameEl.value;

        fetch("https://localhost:5001/Ocena/DodajOcenu/"+gameplay+"/"+story+"/"+music+"/"+graphics+"/"+idIgre+"/"+usernameKorisnika,
        {
            method:"POST"
        }).then( s=>
            {
                if(s.status == 400)
                {
                    alert("Korisnik je vec uneo ocenu za odabranu igru");
                    return;
                }
                if(s.status == 403)
                {
                    alert("Dati korisnik ne postoji.Morate se registrovati!");
                    return;
                }
                if (s.status == 200)
                {
                    var teloTabele = this.obrisiPrethodniSadrzajIgra();
                    s.json().then(s=>
                    {
                        const i = new Igra(s.id, s.naziv, s.zanr, s.godinaIzlaska, s.developer, s.publisher, s.prosecnaOcena);
                        i.crtaj(teloTabele);
                    });
                   
                }
            })

    }

    obrisiOcenu()
    {
        let igraOptionEl2 = this.kontejner.querySelector("select[className='selectIgra']");
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

    obrisiPrethodniSadrzajIgra()
    {
        var teloTabele = document.querySelector(".TabelaPodaciIgra");
        var roditelj = teloTabele.parentNode;
        roditelj.removeChild(teloTabele);

        teloTabele = document.createElement("tbody");
        teloTabele.className="TabelaPodaciIgra";
        roditelj.appendChild(teloTabele);
        return teloTabele;
    }

    obrisiPrethodniSadrzajKorpa()
    {
        var teloTabele = document.querySelector(".TabelaPodaciKorpa");
        var roditelj = teloTabele.parentNode;
        roditelj.removeChild(teloTabele);

        teloTabele = document.createElement("tbody");
        teloTabele.className="TabelaPodaciKorpa";
        roditelj.appendChild(teloTabele);
        return teloTabele;
    }

    obrisiPrethodniSadrzajNagrada()
    {
        var teloTabele = document.querySelector(".TabelaPodaciNagrada");
        var roditelj = teloTabele.parentNode;
        roditelj.removeChild(teloTabele);

        teloTabele = document.createElement("tbody");
        teloTabele.className="TabelaPodaciNagrada";
        roditelj.appendChild(teloTabele);
        return teloTabele;
    }

    prikaziNagrade()
    {
        let igraOptionEl3 = this.kontejner.querySelector("select[id='selectOcena']");
        var idIgre3 = igraOptionEl3.options[igraOptionEl3.selectedIndex].value;

        fetch("https://localhost:5001/Nagrada/PreuzmiNagrade/"+idIgre3,
        {
            method:"GET"
        }).then( s=>
            {
               if (s.status == 200)
               {
                   var teloTabele = this.obrisiPrethodniSadrzajNagrada();
                   s.json().then(data=>{
                       data.forEach(s=>{
                           const n = new Nagrada(s.id, s.nazivOrg, s.kategorija, s.igraFK);
                           n.crtaj(teloTabele);
                       });
                   })
               }
            })
    }

    dodajUKorpu(korpa)
    {
        if(korpa <= 0)
        {
            alert("Unesite odgovarajucu kolicinu");
            return;
        }

        let igraOptionEl = this.kontejner.querySelector("select[id='selectProdavnica']");
        var idIgre = igraOptionEl.options[igraOptionEl.selectedIndex].value;
        var imeIgre = igraOptionEl.options[igraOptionEl.selectedIndex].innerHTML;

        var teloTabele = this.obrisiPrethodniSadrzajKorpa();
        fetch("https://localhost:5001/Prodavnica/PreuzmiArtikl/"+idIgre,
        {
            method:"GET"
        }).then(s=>{
            if(s.ok)
            {
                s.json().then(s=>
                    {
                        const p = new Prodavnica(s.id, s.cenaIgre, s.kolicinaProdatih, korpa, imeIgre,s.igraFK);
                        p.crtaj(teloTabele);
                    })
            }
        })

    }

    obaviKupovinu(korpa)
    {
        if(korpa <= 0)
        {
            alert("Unesite odgovarajucu kolicinu");
            return;
        }

        let igraOptionEl = this.kontejner.querySelector("select[id='selectProdavnica']");
        var idIgre = igraOptionEl.options[igraOptionEl.selectedIndex].value;

        fetch("https://localhost:5001/Prodavnica/PromeniKolicinuProdatih/"+idIgre+"/"+korpa,
        {
            method:"PUT"
        }).then(s=>{
            if(s.status == 200)
                {
                    alert("Kupovina obavljena!");
                    return;
                }
        })
    }

    prikaziSliku()
    {   
        let igraOptionEl = this.kontejner.querySelector("select[id='selectSlika']");
        var idIgre = igraOptionEl.options[igraOptionEl.selectedIndex].value;

        var slika = document.getElementById("slikaZaPrikaz");
        slika.src = "../Slike/"+idIgre+".jpg";
    }

}