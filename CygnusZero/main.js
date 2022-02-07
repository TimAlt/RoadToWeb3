/** Connect to Moralis server */
const serverUrl = "https://cqiylamgwmcw.usemoralis.com:2053/server";
const appId = "VdSC2NRduLhy1xS54VEUMhzQMeWYzpLlRpP64lty";
Moralis.start({ serverUrl, appId });

/** Add from here down */
async function login() {
  let user = Moralis.User.current();
  if (!user) {
   try {
      user = await Moralis.authenticate({ signingMessage: "Hello World!" })
      console.log(user)
      window.unityInstance.SendMessage('Web3', 'MoralisConnected', 'true')
      window.unityInstance.SendMessage('Web3', 'LoggedIn', 'true')
      console.log(user.get('ethAddress'))

      // const options = { address: "0x2d4e9B56A0bBf2EEd1FC355b689dDc6f5c3504b1", chain: "polygon" };
      // const nftOwners = await Moralis.Web3API.token.getNFTOwners(options);
      const options = { chain: 'polygon', token_address: '0x2d4e9B56A0bBf2EEd1FC355b689dDc6f5c3504b1'};
      const polygonNFTs = await Moralis.Web3API.account.getNFTsForContract(options);
      console.log(polygonNFTs)
      window.unityInstance.SendMessage('Web3', 'JsonData', JSON.stringify(polygonNFTs))
   } catch(error) {
     console.log(error)
   }
  }
  
}

async function logOut() {
  await Moralis.User.logOut();
  window.unityInstance.SendMessage('Web3', 'MoralisConnected', 'false')
  window.unityInstance.SendMessage('Web3', 'LoggedIn', 'false')
  console.log("logged out");
}

document.getElementById("btn-login").onclick = login;
document.getElementById("btn-logout").onclick = logOut;

/** Useful Resources  */

// https://docs.moralis.io/moralis-server/users/crypto-login
// https://docs.moralis.io/moralis-server/getting-started/quick-start#user
// https://docs.moralis.io/moralis-server/users/crypto-login#metamask

/** Moralis Forum */

// https://forum.moralis.io/
