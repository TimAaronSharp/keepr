<template>
    <div class="register-modal">
        <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#register-modal">
            Register
        </button>

        <div class="modal fade" id="register-modal" tabindex="-1" role="dialog" aria-labelledby="register-modal-label">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header row">
                        <!-- <h4 class="modal-title" id="myModalLabel">Modal title</h4> -->
                    </div>
                    <div class="modal-body">
                        <div class="register-body form">
                            <form class="form" id="register" @submit="submitRegister">
                                <div class="form-group">
                                    <label for="register-username">
                                        <span class="glyphicon glyphicon-user"></span> User Name</label>
                                    <input type="text" class="form-control" id="register-username" placeholder="JohnnyAwesome" v-model='register.userName'>
                                </div>
                                <div class="form-group">
                                    <label for="register-first-name">
                                        <span class="glyphicon glyphicon-user"></span> First Name</label>
                                    <input type="text" class="form-control" id="register-first-name" placeholder="Johnny" v-model='register.firstName'>
                                </div>
                                <div class="form-group">
                                    <label for="register-last-name">
                                        <span class="glyphicon glyphicon-user"></span> Last Name</label>
                                    <input type="text" class="form-control" id="register-last-name" placeholder="Regular" v-model='register.lastName'>
                                </div>
                                <div class="form-group">
                                    <label for="register-email">
                                        <span class="glyphicon glyphicon-user"></span> Email</label>
                                    <input type="email" class="form-control" id="register-email" placeholder="woot1337h4xors@rockulikeahurricane.org" v-model='register.email'>
                                </div>
                                <div class="form-group">
                                    <label for="register-password">
                                        <span class="glyphicon glyphicon-eye-open"></span> Password</label>
                                    <input type="password" class="form-control" id="password" placeholder="eyelessthan3horses" v-model='register.password'>
                                </div>
                                <div class="form-group">
                                    <label for="register-avatarurl">
                                        <span class="glyphicon glyphicon-user"></span> Avatar URL</label>
                                    <input type="url" class="form-control" id="register-avatarurl" placeholder="http://placehold.it/200x200" v-model='register.avatarURL'>
                                </div>
                                <button type="submit" class="btn btn-default btn-success" data-toggle="modal" data-backdrop="false">
                                    Register</button>
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
        name: '',
        data() {
            return {
                register: {
                    userName: '',
                    firstName: '',
                    lastName: '',
                    email: '',
                    password: '',
                    avatarURL: ''
                }

            }
        },
        mounted() {

        },

        methods: {
            submitRegister() {
                this.$store.dispatch('submitRegister', this.register)
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