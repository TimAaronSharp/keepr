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

      <div class="pull-right" v-if="user.firstName">
        <button class="btn custom-btn account-btn" type="button" @click="logout">Logout</button>
      </div>

      <div v-else>
        <Register></Register>
        <Login></Login>

      </div>

    </nav>
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

  /* .vert-align { 
     min-height:; 
     margin: auto 0;
    display: flex;
    align-items: center;
  } */
</style>