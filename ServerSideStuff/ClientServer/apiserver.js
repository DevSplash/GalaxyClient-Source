const express = require('express')
const path = require('path')
const bodyParser = require('body-parser')
const mongoose = require('mongoose')
const fs = require('fs')
//const User = require('./model/user')
const { MongoClient } = require("mongodb");

const JWT_SECRET = 'sdjkfh8923yhjdksbfma@#*(&@*!^#&@bhjb2qiuhesdbhjdsfg839ujkdhfjk'

const JUSTANINT = "0"

const app = express()
app.use('/', express.static(path.join(__dirname, 'static')))
app.use(bodyParser.json())


app.post('/api/GetCore', async (req, res) => {
	async function run() {
		const { Key, Hwida, BETA } = req.body
	     const uri = "PUT MONGO SERVER LINK HERE";
		 const client = new MongoClient(uri);
	try
	{
	
    
	await client.connect();
	const database = client.db("Astrum");
	const User = database.collection("userinfo");
	const user = await User.findOne({ Key })

	if (!user) {
		//return res.json({ status: 'error', error: 'Invalid username/password' })
		await client.close();
		return res.status(404).send('Not Found');
	}

	if (user.HWID == JUSTANINT)
	{
		
		console.log("STARTING UPDATE")
		const filter = { Key: Key };
        // this option instructs the method to create a document if no documents match the filter
        const options = { upsert: false };
   const updateDoc = {
	   $set: {
		 HWID: `${Hwida}`
	   },
	 };
	 const result = await User.updateOne(filter, updateDoc, options);
	 console.log("updated HWID")

   }

   if (Key == user.Key && Hwida == user.HWID && BETA != JUSTANINT && user.hasBeta == JUSTANINT) {
	// the username, password combination is successful
	console.log("1")
	await client.close();
	return res.status(417)
	//return res.json({ status: 'ok', data: "SUCESS LOGGING IN TO CLIENT" })
	console.log("Sucess sending data")
}
   if (Key == user.Key && Hwida == user.HWID && BETA != JUSTANINT && user.hasBeta != JUSTANINT) {
	// the username, password combination is successful
	console.log("2")
	await client.close();
	return res.status(200).sendFile('GalaxyClientBeta.dll', {root: __dirname})
	await client.close();
	//return res.json({ status: 'ok', data: "SUCESS LOGGING IN TO CLIENT" })
	console.log("Sucess sending data")
}



	if (Key == user.Key && Hwida == user.HWID) {
		// the username, password combination is successful
	
		await client.close();
		return res.status(200).sendFile('GalaxyClient.dll', {root: __dirname})
		//return res.json({ status: 'ok', data: "SUCESS LOGGING IN TO CLIENT" })
		console.log("Sucess sending data")
		
	}
	
	res.status(401).send('Not Found');
	//res.json({ status: 'error', error: 'Invalid username/password' })
        }  	finally { await client.close(); }}run().catch(console.dir);})
		
app.get('/api/GetUpdates', async (req, res) => {
	const APCCrash = fs.readFileSync("PCCrash.txt", "utf8");
	const AQuest = fs.readFileSync("Quest.txt", "utf8");
	const TagList = fs.readFileSync("TagList.txt", "utf8");
	const Stafftag = fs.readFileSync("StaffTagList.txt", "utf8");

	var becomingajson = JSON.stringify({PCCrash: `${APCCrash}`,QuestCrash:`${AQuest}`,TagList: `${TagList}`,StaffTagList: `${Stafftag}`})

	return res.status(200).send(becomingajson);


})


app.listen(2052, () => {
	console.log('Server up at 8034')
})
