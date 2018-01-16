<template>
  <div class="home container">
    <div class="welcome-message" v-if="user.firstName">
      <h1>Welcome {{user.firstName}}</h1>
      <button type="button" @click="logout">Logout</button>
      <NewKeep></NewKeep>
      <NewVault></NewVault>
      <Vault></Vault>
      <ShowKeeps></ShowKeeps>
    </div>
    <div class="welcome-message" v-else>
      <h1>Please login</h1>
      <Login></Login>
      <Register></Register>
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
      Register
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>



<!-- <button type="button" class="btn btn-default btn-md" data-toggle="modal" data-target="#loginModal">Login</button>
    <div class="modal fade login" id="loginModal" tabindex="-1" role="dialog" aria-labelledby="loginModal" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content logininfo form">
          <div class="login-header form">
            <button type="button" class="close" data-dismiss="modal" data-backdrop="false" aria-hidden="true">&times;</button>
            <h4 style="color:black;"> Login</h4>
          </div>
          <div class="login-body form">
            <form class="form" id="login" @submit="submitLogin">
              <div class="form-group">
                <label for="email">
                  <span class="glyphicon glyphicon-user"></span> Email</label>
                <input type="text" class="form-control" id="email" placeholder="woot1337h4xors@rockulikeahurricane.org" v-model='login.email'>
              </div>
              <div class="form-group">
                <label for="password">
                  <span class="glyphicon glyphicon-eye-open"></span> Password</label>
                <input type="password" class="form-control" id="password" placeholder="eyelessthan3horses" v-model='login.password'>
              </div>
              <button type="submit" class="btn btn-default btn-success btn-block" data-toggle="modal" data-backdrop="false">
                Login</button>
            </form>
          </div>
          <div class="login-footer form">
            <button type="submit" class="btn btn-default btn-md pull-left" data-dismiss="modal" datat-target="#loginModal">
              <span class="glyphicon glyphicon-remove"></span> Cancel</button>
            <p>Not a member?
              <button type="button" class="btn btn-default btn-md" onclick="app.controllers.authController.changeup()">Sign Up</button>
            </p>
            <div id="reg">

              <form class="form" id="registration" @submit="submitRegister">
                <div class="form-group">
                  <label for="username">Username:</label>
                  <input type="text" class="form-control" name="username" placeholder="newGamer" v-model='register.username' required>
                </div>
                <div class="form-group">
                  <label for="email">Email address:</label>
                  <input type="email" class="form-control" name="email" placeholder="newGamer@rockyoulikeahurricane.org" v-model='register.email'
                    required>
                </div>
                <div class="form-group">
                  <label for="password">Password: </label>
                  <input type="password" class="form-control" name="password" placeholder="thec4keisalie" v-model='register.password' required>
                </div>
                <div class="form-group">
                  <label for="reEnterPassword">Re-enter Password: </label>
                  <input type="password" class="form-control" name="reEnterPassword" placeholder="enteritagain" v-model='register.password' required>
                </div>
                <div class="form-group">
                  <button type="submit" class="btn btn-default btn-success btn-block" data-toggle="modal">
                    Submit </button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div> -->