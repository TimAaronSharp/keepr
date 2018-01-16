<template>
    <div class="login-component">
        <div class="wrapper pull-right">
            <button type="button" class="btn custom-btn account-btn" data-toggle="modal" data-target="#login-modal">
                Login
            </button>
        </div>
        <div class="modal fade" id="login-modal" tabindex="-1" role="dialog" aria-labelledby="login-modal-label">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header row">
                        <!-- <h4 class="modal-title" id="myModalLabel">Modal title</h4> -->
                    </div>
                    <div class="modal-body">
                        <div class="login-body form">
                            <form class="form" id="login" @submit="submitLogin">
                                <div class="form-group">
                                    <label for="login-email">
                                        <span class="glyphicon glyphicon-user"></span> Email</label>
                                    <input type="email" class="form-control" id="login-email" placeholder="woot1337h4xors@rockulikeahurricane.org" v-model='login.email'>
                                </div>
                                <div class="form-group">
                                    <label for="password">
                                        <span class="glyphicon glyphicon-eye-open"></span> Password</label>
                                    <input type="password" class="form-control" id="login-password" placeholder="eyelessthan3horses" v-model='login.password'>
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

</template>

<script>
    export default {
        name: 'Login',
        data() {
            return {
                login: {
                    email: '',
                    password: ''
                }

            }
        },
        mounted() {

        },

        methods: {
            submitLogin() {
                this.$store.dispatch('submitLogin', this.login)
            }

        },
        computed: {

        },
        components: {

        }
    }

</script>

<style>
</style>