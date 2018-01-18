<template>
  <div class="home container-fluid">
    <nav class="navbar-static-top row fixed">
      <div class="pull-left logo-div">
        <img class="logo-img" src="../assets/keepr-logo.png" alt="">
      </div>
      <div class="welcome-message pull-left" v-if="user.firstName">
        <h1>Welcome, {{user.firstName}}</h1>
      </div>
      <div class="welcome-message pull-left" v-else>
        <h1>Welcome to Keepr</h1>
      </div>

      <div class="account-btn pull-right" v-if="user.firstName">
        <button class="btn custom-btn" type="button" @click="logout">Logout</button>
      </div>
      <div class="wrapper account-btn pull-right ilb" v-else>
        <button type="button" class="btn custom-btn" data-toggle="modal" data-target="#login-modal">
          Login
        </button>
        <button type="button" class="btn custom-btn" data-toggle="modal" data-target="#register-modal">
          Register
        </button>

      </div>

    </nav>

    <h1 class="share-message">YOU DON'T HAVE ANY FRIENDS TO SHARE WITH</h1>
    <div v-if="!user.firstName">
      <Register></Register>
      <Login></Login>

    </div>

    <Sidebar></Sidebar>
    <!-- <ShowKeeps class="il"></ShowKeeps> -->
    <KeepArea></KeepArea>

  </div>
</template>

<script>
  // import ShowKeeps from './ShowKeeps'
  import Login from './Login'
  import Register from './Register'
  import Sidebar from './Sidebar'
  import KeepArea from './KeepArea'

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
      // ShowKeeps,
      Login,
      Register,
      Sidebar,
      KeepArea
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  nav {
    background: #fa0296;
    color: white;
    min-width: 100vw;
  }

  .wrapper {
    position: relative;
  }

  .share-message {
    font-size: 20rem;
    position: absolute;
    color: yellow;
    top: 10%;
    z-index: 50;
    display: none;
  }

  #share-effect {
    display: block;
  }

  /* .share-message:active {
    
  } */

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

  .fixed {
    position: fixed;
  }

  .top-level {
    z-index: 50;
  }

  /* .vert-align { 
     min-height:; 
     margin: auto 0;
    display: flex;
    align-items: center;
  } */
</style>