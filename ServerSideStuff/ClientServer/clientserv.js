const WebSocket = require("ws");  
const fs = require('fs');
const crypto = require("crypto");
const wss = new WebSocket.Server({port: 8080});
const KEYpass = Buffer.from("arandomkey", "utf8");
const path = require('path')
//const { MessageEmbed, WebhookClient, Discord } = require('discord.js');
// we create 'users' collection in newdb database

const { MongoClient } = require("mongodb");

 




//const webhookClient = new WebhookClient({ url: 'https://discord.com/api/webhooks/975746205424439357/wRSS_-Xv1Tug_H1bp4Br3coakUTrl-3XHIJ0fa6ireE-bgnHhcOoGPMtvF7TfMzNcbeW' });
//////////////////////////////////////
//This does not require any type of db its raw json
//////////////////////////////////////

try
{let date_ob = new Date();

    let date = ("0" + date_ob.getDate()).slice(-2);
    
    let month = ("0" + (date_ob.getMonth() + 1)).slice(-2);
    
    let year = date_ob.getFullYear();
    
    let hours = date_ob.getHours();
    
    let minutes = date_ob.getMinutes();
    
    let seconds = date_ob.getSeconds();

    let stringaa = "Y [" + year + "] - M [" + month + "] - D[" + date + "] - HMS [" + hours + ":" + minutes + ":" + seconds + "]";
    fs.writeFileSync("txt file where u want the last time the node restarted", stringaa)
} 
catch (error) {
    console.log(error);
}


try {
    wss.broadcast = function broadcast(msg) {
       // console.log(msg);
        wss.clients.forEach(function each(client) {
            try
            {
                if (client.uid.includes("usr_"))
                client.send(Buffer.from(msg).toString('base64'));
            }
            catch(error){console.log(error)
            }
            
           
         });
     };
} catch (error) {
    console.log(error);
}



wss.on("connection", (ws,req) => {

   

   ws.on('message',message => {

    let active = wss.clients.size;
    var users = JSON.stringify({users: `${active}`})

    fs.writeFileSync(path.resolve(__dirname, "../users"), users)


  

    let deserializedmsg;
    try {
        deserializedmsg = JSON.parse(message);
        
        if (deserializedmsg.code > 90)
        return;
    }
    catch(error)
    {
        console.log(error);
        return;
    }

    

    switch(deserializedmsg.code)
    {
        case "1":
            console.log(deserializedmsg.Custommsg);
           if(deserializedmsg.Custommsg.length < 50)
           ws.uid = deserializedmsg.Custommsg;
        break;
        case "2":
            try
            {
                forwordchatmsg(deserializedmsg.clientpassword,deserializedmsg.clientKey,deserializedmsg.clientmessage);
            }
            catch(error)
            {
                console.log(error);
                return;
            }
        break;
        case "5":
            try
            {
               Addplate(ws,deserializedmsg.Custommsg);
            }
            catch(error)
            {
                console.log(error);
                return;
            }
        break;
        case "6":
            try
            {
                Addnewtag(deserializedmsg.userid,deserializedmsg.key,deserializedmsg.password,deserializedmsg.addnewtagtouser);
            }
            catch(error)
            {
                console.log(error);
                return;
            }
        break;
        case "7":
            try
            {
                Removealltags(deserializedmsg.abouttoremovealltagskey,deserializedmsg.password);
            }
            catch(error)
            {
                console.log(error);
                return;
            }
        break;
        case "8":
            try
            {
                movetags(deserializedmsg.userid,deserializedmsg.tomovetagstouserkey,deserializedmsg.password);
            }
            catch(error)
            {
                console.log(error);
                return;
            }

        break;

        case "9":
            try
            {
                LogAvitodb(deserializedmsg.AvatarName,deserializedmsg.Author,deserializedmsg.Authorid,deserializedmsg.Avatarid,deserializedmsg.Description,deserializedmsg.Asseturl,deserializedmsg.Image,deserializedmsg.Platform,deserializedmsg.Status);
            }
            catch(error)
            {
                console.log(error);
                return;
            }

        break;
        case "10":
            try
            {
                if (deserializedmsg.Custommsg.length > 1)
                serchavatar(ws,deserializedmsg.Custommsg);
            }
            catch(error)
            {
                console.log(error);
                return;
            }

        break;
        case "12":
            try
            {
                if (deserializedmsg.Custommsg.length > 1)
                SetGlobal(ws,deserializedmsg.Custommsg);
            }
            catch(error)
            {
                console.log(error);
                return;
            }

        break;
        case "13":
            try
            {
                Setpassword(deserializedmsg.Key,deserializedmsg.Hwid,deserializedmsg.Password,deserializedmsg.User);
            }
            catch(error)
            {
                console.log(error);
                return;
            }
        break;
        case "14":
            try
            {
                loginuser(ws,deserializedmsg.key,deserializedmsg.Hwida,deserializedmsg.ExtraBeta);
            }
            catch(error)
            {
                console.log(error);
                return;
            }
        break;
      /*  case "18":
            try
            {
                
                hwidcheck(ws,deserializedmsg.key,deserializedmsg.Hwida);
            }
            catch(error)
            {
                console.log(error);
                return;
            }
        break;*/
        case "19":
            try
            {
                
                BANKEY(ws,deserializedmsg.key,deserializedmsg.Hwida);
            }
            catch(error)
            {
                console.log(error);
                return;
            }
        break;
        case "20":
            try
            {
                getserverupdates(ws);
            }
            catch(error)
            {
                console.log(error);
                return;
            }
        break;
       /* case "22":
            try
            {
                
                staffsetservermsg(ws,deserializedmsg.key,deserializedmsg.keyb);
            }
            catch(error)
            {
                console.log(error);
                return;
            }
        break;*/
        case "52":
            try
            {
                Sendclient(ws,req,deserializedmsg.key,deserializedmsg.Hwid)
            }
            catch(error)
            {
                console.log(error);
                return;
            }
        break;
        case "11":
            try
            {
                CheckStaff(ws,req,deserializedmsg.Location)
            }
            catch(error)
            {
                console.log(error);
                return;
            }
        break;
       
    };

   });
   
        
    ws.on("close", () => {
        
        console.log("Client Disconnected.");
        let active = wss.clients.size;
        var users = JSON.stringify({users: `${active}`})
        fs.writeFileSync(path.resolve(__dirname, "../users"), users)
    });
 
  

    });
console.log("Server Started");



function SetGlobal(ws,serchtext)
{

    fs.writeFile('GLOBALMESSAGE', `GlobalMSG ${serchtext}`, err => {
        if (err) {
          console.error(err)
          return
        }
        //file written successfully
      })

}


function getserverupdates(ws)
{

const data = fs.readFileSync("GLOBALMESSAGE", "utf8");
ws.send(Buffer.from(data).toString('base64'));

}


function staffsetservermsg( key, keyb)
{




    const uri = "Insert Mongo Link  Here";
    const client = new MongoClient(uri);
    async function run() {
      try {
        await client.connect();
        const database = client.db("Astrum");
        const movies = database.collection("userinfo");
        // Query for a movie that has the title 'The Room'
        const query = { Key: `${key}` };
      
        const Authme = await movies.findOne(query);
console.log(Authme)

//console.log(Authme.key)
console.log(Authme)
const justme = null
if (Authme == null)
{ws.send(Buffer.from("UserNotAuth").toString('base64'));
return;
      }
else 
var IsStaffINT = 1
if (Authme.IsStaff == IsStaffINT && Authme.Key == key)
{
    
    fs.writeFileSync("GLOBALMESSAGE", `Global Message ${key}`)

}


    } finally {
        await client.close();
      }
    }
    run().catch(console.dir);  }


function findGlow(ws,Location)
{
    console.log("Should log")
    const data = fs.readFileSync("GlowsLocation", "utf8");
    //var tobecomemsg = JSON.stringify({data})
    ws.send(data.glowlocation);
    console.log("abcd")
    console.log(data)
    var tobecometag = JSON.stringify({Location: data.glowlocation})
    console.log(tobecometag)
    ws.send(Buffer.from(data).toString('base64'));
    //ws.send(Buffer.from(JSON.stringify(arr)).toString('base64'));

}

function LogGlow(Locationaabc)
{
    
    //const data = fs.writeFile("Glowlocation", "utf8");
   // var tobecomemsg = JSON.stringify({hislocation: "abcd", code: "8562"})
   // wss.broadcast(tobecomemsg);
    //console.log("abcd")
    //ws.broadcast(Buffer.from(JSON.stringify(tobecomemsg)).toString('base64'));
    //fs.writeFileSync("Glowlocation",JSON.stringify(Locationaabc))
    var becomingajson = JSON.stringify({GlowLocation:Locationaabc})
 
     fs.writeFileSync("GlowsLocation",becomingajson);

  
  
    fs.writeFileSync("cl/rolesmanager.json",Locationaabc)
    console.log(Locationaabc)
}


function forwordchatmsg(password, clientKey, msg)
 {      
     var encppass = encrypt(password, KEYpass, "base64");
     var encpkey = encrypt(clientKey, KEYpass, "base64");

    const data = fs.readFileSync("a place for you pass", "utf8");
    if (data.includes(encpkey))
    {
        let jss = JSON.parse(data);
        jss.forEach(function(datas) {
            if (datas.Key == encpkey && datas.Password == encppass && msg.length >= 3 && msg.length < 75 && !msg.includes("\n"))
            {
              var tobecomemsg = JSON.stringify({clinetmessage: msg, uid: datas.uid,user: datas.User,code: "2"})
              wss.broadcast(tobecomemsg);
            }
        });
    }
  }

//Adds a plate to the User

  function Addplate(ws,userid)
  {
    if (userid.includes("usr_") && userid.toString().length < 50)
    {
        const data = fs.readFileSync("cl/rolesmanager.json", "utf8");
        if (data.includes(userid))
        {
            let jss = JSON.parse(data);
            jss.forEach(function(datas) {
               if (datas.userid == userid)
               {
                    ws.send(Buffer.from(JSON.stringify(datas)).toString('base64'));
               }
            });
            return;
        }
        wss.clients.forEach(function each(client) {
            if (client.uid == userid)
            {
                var tobecometag = JSON.stringify({userid: client.uid, permision: "0", roleslist:["<color=#10001c>N</color> <color=#3e006b>T</color><color=#4f0087>r</color><color=#580096>u</color><color=#6400ab>s</color><color=#6f02bd>t</color><color=#8300e0>e</color><color=#9500ff>d"]})
                ws.send(Buffer.from(tobecometag).toString('base64'));
  
            }
        });
    }
  }
  

 //Creates or adds a new tag to the User

 function Addnewtag(uid,ecnkey,password,tag)
{
    
        if (tag.length > 300)
            return;
        if (tag.includes("\n"))
            return;
        if (tag.includes("<size="))
           return;
  
        const datar = fs.readFileSync("cl/rolesmanager.json", "utf8");
        var encpkey = encrypt(ecnkey, KEYpass, "base64");
        var encppass = encrypt(password, KEYpass, "base64");


        const passwordinfo = fs.readFileSync("pass file", "utf8");
        var arr2 = [];
        if (datar.includes(encpkey))
        {
            let jsconv = JSON.parse(passwordinfo);
            jsconv.forEach(function(passwordinfoass) {
               

                if (passwordinfoass.Key == encpkey && passwordinfoass.Password == encppass)
                {
  
                    let jss = JSON.parse(datar);
                    jss.forEach(function(datas) {
                        if (datas.roleslist.length <= Number(datas.permision) && datas.key == encpkey)
                        {
                                datas.roleslist.push(tag);
                             
                                arr2.push(datas);
                        }
                        else
                        arr2.push(datas);
  
  
                });
                fs.writeFileSync("cl/rolesmanager.json",JSON.stringify(arr2))
                }
            });
  


        }  
        else
        {
  
            let jsconv = JSON.parse(passwordinfo);
            jsconv.forEach(function(passwordinfoass) {
  
                if (passwordinfoass.Key == encpkey && passwordinfoass.Password == encppass)
                {

                    var tobecomestring = JSON.stringify({userid: uid, permision: "3",roleslist: [tag],key: encpkey})
                    var tosend = datar.toString().slice(0,-1) + "," + tobecomestring + "]";
                    fs.writeFileSync("cl/rolesmanager.json", tosend)
                }
  
            });
        }    
}
  
 //Moving the tags to the current user id


    function movetags(uid,key,password)
 {
     var encpkey = encrypt(key, KEYpass, "base64");
     var encppass = encrypt(password, KEYpass, "base64");

        const datar = fs.readFileSync("cl/rolesmanager.json", "utf8");
        const passwordinfo = fs.readFileSync("pass file", "utf8");
        var arr2 = [];
        if (datar.includes(encpkey))
        {
            let jsconv = JSON.parse(passwordinfo);
            jsconv.forEach(function(passwordinfoass) {
               
                if (passwordinfoass.Key == encpkey && passwordinfoass.Password == encppass)
                {
   
                    let jss = JSON.parse(datar);
                    jss.forEach(function(datas) {
                        if (datas.key == encpkey)
                        {
                                datas.userid = uid;
                                arr2.push(datas);
                        }
                        else
                        arr2.push(datas);
   
   
                });
                fs.writeFileSync("cl/rolesmanager.json",JSON.stringify(arr2))
   
                }
            });
        }       
         
}
 

 //Removes all the tags from the user

    function Removealltags(keygs,password)
 {
      var encpkey = encrypt(keygs, KEYpass, "base64");
      var encppass = encrypt(password, KEYpass, "base64");

        const datar = fs.readFileSync("cl/rolesmanager.json", "utf8");
        const passwordinfo = fs.readFileSync("pass file", "utf8");
        var arr2 = [];
        if (datar.includes(encpkey))
        {
            let jsconv = JSON.parse(passwordinfo);
            jsconv.forEach(function(passwordinfoass) {
               
                if (passwordinfoass.Key == encpkey && passwordinfoass.Password == encppass)
                {

                    let jss = JSON.parse(datar);
                    jss.forEach(function(datas) {
                        if (datas.key == encpkey)
                        {
                                datas.roleslist = [];
                                arr2.push(datas);
                        }
                        else
                        arr2.push(datas);
                });
                fs.writeFileSync("cl/rolesmanager.json",JSON.stringify(arr2))

                }
            });

        }       
 }
  
 
 //A bool that checks if the user is auth or not

 function loginuser(ws,key,Hwida,ExtraBeta)
{
const uri = "Insert Mongo Link  Here";
    const client = new MongoClient(uri);
    async function run() {
      try {
        await client.connect();
        const database = client.db("Astrum");
        const movies = database.collection("userinfo");
// Query the db for the specifyed key
        const query = { Key: `${key}` };
        const Authme = await movies.findOne(query);
          
        await client.close();
// simple check to make sure user actually has key before we run logic
if (Authme == null)
{ws.send(Buffer.from("UserNotAuthInvalidKey").toString('base64'));
await client.close();
return;
}

if ( Authme.Key == key && Authme.HWID != Hwida)
{
ws.send(Buffer.from("UserNotAuthInvalidHWID").toString('base64'));
await client.close();
return;
}

var JustCheck = 1
if ( Authme.Key == key && Authme.banned == JustCheck)
{
ws.send(Buffer.from("UserNotAuthBan").toString('base64'));
await client.close();
return;
}

// Check For Beta this requires Client to  send # 1 as string named ExtraBeta must also match the db 
if (Authme.hasBeta == JustCheck && Authme.Key == key && Authme.HWID == Hwida && ExtraBeta == JustCheck)
{ws.send(Buffer.from("ExtraBeta").toString('base64'));
await client.close();}
// bool to check of user is staff
if (Authme.IsStaff == JustCheck && Authme.Key == key && Authme.HWID == Hwida)
{ws.send(Buffer.from("IsStaff").toString('base64'));
await client.close();}
//Bool to check to make sure user is actually authenticated to make sure shit loads properly
if (Authme.Key == key && Authme.HWID == Hwida)
{ws.send(Buffer.from("UserAuth").toString('base64')); 
await client.close();}
else 
ws.send(Buffer.from("UserNotAuthUnknownWhy").toString('base64'));
// just close the db so we can log shit later ovi
await client.close();
} 
finally { await client.close(); }}run().catch(console.dir);  }



  /*      function hwidcheck(ws,key,Hwida)
 {
//does hwid cheack and saves it 
  // Replace the uri string with your MongoDB deployment's connection string.
  const uri = "Insert Mongo Link  Here";
  const client = new MongoClient(uri);
  async function run() {
    try {
      await client.connect();
      const database = client.db("Astrum");
      const Search = database.collection("userinfo");
     
        
     
      const movies = database.collection("Test");
//search For key
      const query = { Key: `${key}` };
  //  console.log(query)
      const AvatarNamea = await Search.findOne(query);
 
const HWIDREFERENCE = 0
if(AvatarNamea.HWID == HWIDREFERENCE )
{
//console.log(HWIDREFERENCE)
    const uri = "Insert Mongo Link  Here";
    const client = new MongoClient(uri);
    
  async function run() {
      try {
        await client.connect();
        const database = client.db("Astrum");
        const movies = database.collection("userinfo");
        // create a filter for a movie to update
        const filter = { Key: key };
        // this option instructs the method to create a document if no documents match the filter
        const options = { upsert: false };
        // create a document that sets the plot of the movie
        const updateDoc = {
          $set: {
            HWID: `${Hwida}`
          },
        };
        const result = await movies.updateOne(filter, updateDoc, options);
        await client.close();
      } finally {
        
      }
    }
    run().catch(console.dir);  
}
  } finally {
      
    }
  }
  run().catch(console.dir);
 // console.log('nigger')
}*/


function BANKEY(ws,key,Hwida)
{

   const uri = "Insert Mongo Link  Here";
   const client = new MongoClient(uri);
   
 async function run() {
     try {
       await client.connect();
       const database = client.db("Astrum");
       const movies = database.collection("userinfo");
       // Find Users KEY to ban
       const filter = { Key: key };
       // this option instructs the method to create a document if no documents match the filter
       const options = { upsert: false };
       // update the Banned prefix to ban a user
       const updateDoc = {
         $set: {
           banned: "1"
         },
       };
       const result = await movies.updateOne(filter, updateDoc, options);
      
     } finally {
       await client.close();
     }
   }
   run().catch(console.dir);  
}


 
                
        





 
//Setting an optional password to the user

    function Setpassword(Key,Hwid,Password,usr)
 {
    var encpkey = encrypt(Key, KEYpass, "base64");
    var encpass = encrypt(Password, KEYpass, "base64");

            const data = fs.readFileSync("Pass file", "utf8");
            if(!data.includes(encpkey))
            {
              const datass = fs.readFileSync("auth", "utf8");
                let jss = JSON.parse(datass);
                jss.forEach(function(datas) {
                  if (datas.Key == Key && datas.Hwid == Hwid)
                  {
                    const datrm = data.slice(0,-1);
                    var tobecomestring = JSON.stringify({User: usr, Hwid: Hwid,Key: encpkey,Password: encpass,uid: datas.uid})

                    fs.writeFileSync("pass file",  datrm+ "," + tobecomestring + "]")


                  }
                  
           
                });

            }

     

    }


     




 //Log an avatar  to the serverdb

 
 function LogAvitodb(aviname,authorname,authorsid,avatarid,descp,assetrurl,image,platform,stat,)
 {
   /// var becomingajson = JSON.stringify({AvatarName:aviname,Author:authorname,Authorid:authorsid,Avatarid:avatarid,Description:descp,Asseturl:assetrurl,Image:image,Platform:platform,Status:stat})
   // console.log(becomingajson);
     if (avatarid.length > 50)
     return;
     if(!assetrurl.includes("api.vrchat.cloud"))
    return;

     if(!avatarid.includes("avtr_"))
     return;

     const data = fs.readFileSync("avatars", "utf8");
     if(data.includes(avatarid))
     return;
 
     var cutstring = data.slice(0,-1);
 
    // var becomingajson3 = JSON.stringify({AvatarName:aviname,Author:authorname,Authorid:authorsid,Avatarid:avatarid,Description:descp,Asseturl:assetrurl,Image:image,Platform:platform,Status:stat})
     var becomingajson = JSON.stringify({AvatarName:aviname,Author:authorname,Authorid:authorsid,Avatarid:avatarid,Description:descp,Asseturl:assetrurl,Image:image,Platform:platform,Status:stat})
 
     fs.writeFileSync("avatars",cutstring + "," + becomingajson + "]");

    // Replace the uri string with your MongoDB deployment's connection string.
    const uri = "Insert Mongo Link  Here";
    const client = new MongoClient(uri);
    async function run() {
      try {
        await client.connect();
        const database = client.db("Astrum");
        const haiku = database.collection("Avatars");
       
          
       // await client.connect();
       // const database = client.db("Astrum");
        const movies = database.collection("Test");
        // Query for a movie that has the title 'The Room'
        const query = { Avatarid: `${aviname}` };
      
        const AvatarNamea = await movies.findOne(query);
    
     //var becomingajson = JSON.stringify({avatarid: `${AvatarNamea.Avatarid}`})
       

     if(`${AvatarNamea}` == `${aviname}`)
     //  {console.log("exsists skiping")
    {return;}
else {//{console.log("aa")
 { 
       
       
        // create a document to insert
       // console.log('nigger')
        const doc = {
         // title: "Record of a Shriveled Datum",
         // content: "No bytes, no problem. Just insert a document, in MongoDB",
          AvatarName: `${aviname}`,
          Author: `${authorname}`,
          Authorid: `${authorsid}`,
          Avatarid: `${avatarid}`,
          Description:`${descp}`,
          Asseturl: `${assetrurl}`,
          Image: `${image}`,
          Platform:`${platform}`,
          Status: `${stat}`
        }
        const result = await haiku.insertOne(doc);
        await client.close();
        
        console.log(`An Avatar was added with the NAME: ${aviname}`);
    }
}

      } finally {
        await client.close();
      }
    }
    run().catch(console.dir);
   // console.log('nigger')

return;



 }
 
















//Serch an avatar to the server db and return the avatars that contains the name



function serchavatar(ws,serchtext)
{
  /*  const uri = "Insert Mongo Link  Here";
    const client = new MongoClient(uri);
    async function run() {
      try {
        await client.connect();
        const database = client.db("Astrum");
        const movies = database.collection("Avatars");
        // Query for a movie that has the title 'The Room'
        const query = { AvatarName: `${serchtext}` };
      
        const AvatarNamea = await movies.find(query);


        var becomingajson = JSON.stringify({AvatarName: `${AvatarNamea.AvatarName}`,Author: `${AvatarNamea.Author}`,  Authorid: `${AvatarNamea.Authorid}`, Avatarid: `${AvatarNamea.Avatarid}`,Description: `${AvatarNamea.Description}`, Asseturl: `${AvatarNamea.Asseturl}`, Image: `${AvatarNamea.Image}`,Platform: `${AvatarNamea.Platform}`, Status: `${AvatarNamea.Status}`})
        console.log(becomingajson)
        //var becomingajson2 = JSON.stringify({Avatarid: `${AvatarNamea.Avatarid}`})
        
        ws.send(Buffer.from("[" + becomingajson + "]").toString('base64')); 
        //ws.send(Buffer.from(JSON.stringify(movie)).toString('base64')); 
        //ws.send(Buffer.from(JSON.stringify(becomingajson)).toString('base64'))
        // since this method returns the matched document, not a cursor, print it directly
        fs.writeFileSync("trial ", becomingajson)
      //  console.log(becomingajson);
        console.log(AvatarNamea);
        //arr.push(movie);
      } finally {
        await client.close();
      }
    }
    run().catch(console.dir);

*/











    const data = fs.readFileSync("avatars", "utf8");
  

    var arr = [] ;
    let becomingjs = JSON.parse(data);

    becomingjs.forEach(function(datas) {


      
        if (datas.AvatarName.toLowerCase().includes(serchtext) && datas.Status == "public")
        {
            arr.push(datas);
            return;
        }
        if (datas.Author.toLowerCase().includes(serchtext) && datas.Status == "public")
        {             
            arr.push(datas);
            return
        }
        if (eachlts(datas.AvatarName.toLowerCase()).includes(serchtext) && datas.Status == "public")
        {
            arr.push(datas);
            return;
        }
        if (eachlts(datas.Author.toLowerCase()).includes(serchtext) && datas.Status == "public")
        {
            arr.push(datas);
            return;
        }
        if (datas.AvatarName.includes(serchtext) && datas.Status == "public")
        {
            arr.push(datas);
            return;
        }
        if (datas.Author.includes(serchtext) && datas.Status == "public")
        {             
            arr.push(datas);
            return
        }

    });
          ws.send(Buffer.from(JSON.stringify(arr)).toString('base64'));    
         // console.log(JSON.stringify(arr));
          becomingajson = JSON.stringify(arr)
          fs.writeFileSync("pro", becomingajson)


}
















//Send client

function Sendclient(ws,req,key22,hwid)
{
    var auth = false;
    const data2 = fs.readFileSync("Auth", "utf8");
    let jss = JSON.parse(data2);
    jss.forEach(function(datas) {
     
        if (datas.Key == key22 && datas.Hwid == hwid)
        {
            auth = true
        }
        else return;


    })
    if (auth == true)
    {
        fs.readFile("Dll Path",function(err,data){
            if(err){console.log(err)}
            ws.send(data,{binary:true});
        });
    }

}

function encrypt(plainText, key, outputEncoding = "base64") {
    const cipher = crypto.createCipheriv("aes-128-ecb", key, null);
    let encrypted = cipher.update(plainText, 'utf8', outputEncoding)
    encrypted += cipher.final(outputEncoding);
    return encrypted;
}

function decrypt(cipherText, key, outputEncoding = "utf8") {
    const cipher = crypto.createDecipheriv("aes-128-ecb", key, null);
    let encrypted = cipher.update(cipherText)
    encrypted += cipher.final(outputEncoding);
    return encrypted;
}


function eachlts(words) {
    var separateWord = words.toLowerCase().split(' ');
    for (var i = 0; i < separateWord.length; i++) {
       separateWord[i] = separateWord[i].charAt(0).toUpperCase() +
       separateWord[i].substring(1);
    }
    return separateWord.join(' ');
}
 