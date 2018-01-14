<template>
  <div class="home container">
    <div class="welcome-message" v-if="user.firstName">
      <h1>Welcome {{user.firstName}}</h1>
      <button type="button" @click="logout">Logout</button>
    </div>
    <div class="welcome-message" v-else>
      <h1>Please login</h1>
    </div>
    <!-- Button trigger modal -->
    <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">
      Login
    </button>

    <!-- Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header row">
            <!-- <h4 class="modal-title" id="myModalLabel">Modal title</h4> -->
          </div>
          <div class="modal-body">
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
                <button type="submit" class="btn btn-default btn-success" data-toggle="modal" data-backdrop="false">
                  Login</button>
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>

              </form>
            </div>
          </div>
          <div class="modal-footer">

          </div>
        </div>
      </div>
    </div>
    <ShowKeeps></ShowKeeps>
  </div>
</template>

<script>
  import ShowKeeps from './ShowKeeps'
  export default {
    name: 'Home',
    data() {
      return {
        login: {
          email: '',
          password: ''
        },
        register: {
          username: '',
          email: '',
          password: ''
        }
      }
    },
    // mounted() {
    //   this.checkUser()
    // },
    methods: {
      submitLogin() {
        this.$store.dispatch('submitLogin', this.login)
      },
      submitRegister() {
        this.$store.dispatch('submitRegister', this.register)
      },
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
      ShowKeeps
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