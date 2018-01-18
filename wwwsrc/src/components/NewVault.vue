<template>
        <div class="new-vault-modal ilb">
            
            <div class="modal fade" id="post-new-vault-modal" tabindex="-1" role="dialog" aria-labelledby="post-new-vault-modal-label">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-body">
                            <div class="new-vault-body form">
                                <form class="form" id="new-vault" @submit="submitNewVault">
                                    <div class="form-group">
                                        <label for="new-vault-name">
                                            <span class="glyphicon glyphicon-user"></span> Name</label>
                                        <input type="text" class="form-control" minlength="1" required id="new-vault-name" placeholder="Funny Cat Picture" v-model='newVault.name'>
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
                    </div>
                </div>
            </div>
        </div>

</template>

<script>
    export default {
        name: 'NewVault',
        data() {
            return {
                newVault: {
                    userId: '',
                    name: '',
                    description: ''
                }

            }
        },
        mounted() {

        },

        methods: {
            submitNewVault() {
                this.newVault.userId = this.user.id
                this.$store.dispatch('submitNewVault', this.newVault)
            }

        },
        computed: {
            user(){
                return this.$store.state.user
            }
        },
        components: {

        }
    }

</script>

<style>
</style>