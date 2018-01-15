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
    <div class="post-new-keep-modal" v-if="user.firstName">
      <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#postNewKeepModal">
        New Keep
      </button>
      <div class="modal fade" id="postNewKeepModal" tabindex="-1" role="dialog" aria-labelledby="postNewKeepModalLabel">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header row">
              <!-- <h4 class="modal-title" id="myModalLabel">Modal title</h4> -->
            </div>
            <div class="modal-body">
              <div class="new-keep-body form">
                <form class="form" id="new-keep" @submit="submitNewKeep">
                  <div class="form-group">
                    <label for="new-keep-name">
                      <span class="glyphicon glyphicon-user"></span> Name</label>
                    <input type="text" class="form-control" id="new-keep-name" placeholder="Funny Cat Picture" v-model='newKeep.name'>
                  </div>
                  <div class="form-group">
                    <label for="new-keep-description">
                      <span class="glyphicon glyphicon-eye-open"></span> Description</label>
                    <input type="text" class="form-control" id="new-keep-description" placeholder="Cat does something funny" v-model='newKeep.description'>
                  </div>
                  <div class="form-group">
                    <label for="new-keep-imageurl">
                      <span class="glyphicon glyphicon-eye-open"></span> Image URL</label>
                    <input type="text" class="form-control" id="new-keep-imageurl" placeholder="http://placehold.it/200x200" v-model='newKeep.imageURL'>
                  </div>
                  <button type="submit" class="btn btn-default btn-success" data-toggle="modal" data-backdrop="false">
                    Submit</button>
                  <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>

                </form>
              </div>
            </div>
            <div class="modal-footer">

            </div>
          </div>
        </div>
      </div>
      <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#postNewVaultModal">
        New Vault
      </button>
      <div class="modal fade" id="postNewVaultModal" tabindex="-1" role="dialog" aria-labelledby="postNewVaultModalLabel">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header row">
              <!-- <h4 class="modal-title" id="myModalLabel">Modal title</h4> -->
            </div>
            <div class="modal-body">
              <div class="new-vault-body form">
                <form class="form" id="new-vault" @submit="submitNewVault">
                  <div class="form-group">
                    <label for="new-vault-name">
                      <span class="glyphicon glyphicon-user"></span> Name</label>
                    <input type="text" class="form-control" id="new-vault-name" placeholder="Funny Cat Picture" v-model='newVault.name'>
                  </div>
                  <div class="form-group">
                    <label for="new-vault-description">
                      <span class="glyphicon glyphicon-eye-open"></span> Description</label>
                    <input type="text" class="form-control" id="new-vault-description" placeholder="Cat does something funny" v-model='newVault.description'>
                  </div>
                  <!-- <div class="form-group">
                    <label for="new-vault-imageurl">
                      <span class="glyphicon glyphicon-eye-open"></span> Image URL</label>
                    <input type="text" class="form-control" id="new-vault-imageurl" placeholder="http://placehold.it/200x200" v-model='newVault.imageURL'>
                  </div> -->
                  <button type="submit" class="btn btn-default btn-success" data-toggle="modal" data-backdrop="false">
                    Submit</button>
                  <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>

                </form>
              </div>
            </div>
            <div class="modal-footer">

            </div>
          </div>
        </div>
      </div>
    </div>

    <div v-else>
      <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#login-Modal">
        Login
      </button>
    </div>
    <div v-if="!user.firstName">
      <div class="modal fade" id="login-Modal" tabindex="-1" role="dialog" aria-labelledby="loginModalLabel">
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
    </div>
    <Vault></Vault>
    <ShowKeeps></ShowKeeps>
  </div>
</template>

<script>
  import ShowKeeps from './ShowKeeps'
  import Vault from './Vault'
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
        },
        newKeep: {
          userId: '',
          name: '',
          description: '',
          imageURL: ''
        },
        newVault: {
          userId: '',
          name: '',
          description: ''
          // ,
          // imageURL: ''
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
      submitNewKeep() {
        this.newKeep.userId = this.user.id
        debugger
        this.$store.dispatch('submitNewKeep', this.newKeep)
      },
      submitNewVault() {
        this.newVault.userId = this.user.id
        this.$store.dispatch('submitNewVault', this.newVault)
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
      ShowKeeps,
      Vault
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