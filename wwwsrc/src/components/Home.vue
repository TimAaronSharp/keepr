<template>
  <div class="home container-fluid">
    <Sidebar></Sidebar>
    <nav class="row">
      <div class="pull-left logo-div">
        <img class="logo-img" src="../assets/keepr-logo.png" alt="">
      </div>
      <div class="welcome-message pull-left" v-if="user.firstName">
        <h1>Welcome, {{user.firstName}}</h1>
      </div>
      <div class="welcome-message pull-left" v-else>
        <h1>Please login</h1>
      </div>

      <div class="content pull-right" v-if="user.firstName">
        <button class="logout-button" type="button" @click="logout">Logout</button>
      </div>

      <div v-if="!user.firstName">
        <Login class="il"></Login>
        <Register class="il"></Register>
      </div>

    </nav>
    <div v-if="user.firstName">
      <NewKeep class="il"></NewKeep>
      <NewVault class="il"></NewVault>
      <Vault class="il"></Vault>
      <ShowKeeps class="il"></ShowKeeps>
    </div>

    <!-- Button trigger modal -->





  </div>
</template>

<script>
  import ShowKeeps from './ShowKeeps'
  import Vault from './Vault'
  import NewKeep from './NewKeep'
  import NewVault from './NewVault'
  import Login from './Login'
  import Register from './Register'
  import Sidebar from './Sidebar'

  export default {
    name: 'Home',
    data() {
      return {

      }
    },
    // mounted() {
    //   this.checkUser()
    // },
    methods: {
      logout() {
        this.$store.dispatch('logout')
      }
    },
    computed: {
      user() {
        // console.log(this.$store.state.user)
        return this.$store.state.user
      }
    },
    components: {
      ShowKeeps,
      NewKeep,
      NewVault,
      Vault,
      Login,
      Register,
      Sidebar
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  nav {
    background: #fa0296;
    color: white;
  }
  /* .home{
    min-height: 100vh;
  } */

  .il {
    display: inline;
  }

  .logo-img {
    height: 80px;
    width: 100px;
  }

  /* .vert-align { 
     min-height:; 
     margin: auto 0;
    display: flex;
    align-items: center;
  } */

  .logout-button {
    background: black;
    border: 0;
    border-radius: 5px;
    font-size: 2rem;
    margin-top: 35%;
    margin-bottom: 34%;
    margin-right: 20%;
  }
</style>