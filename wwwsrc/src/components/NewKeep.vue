<template>
        <div class="post-new-keep-modal ilb" v-if="user.firstName">
            <button type="button" class="btn btn-primary custom-btn" data-toggle="modal" data-target="#post-new-keep-modal">
                New Keep
            </button>
            <div class="modal fade" id="post-new-keep-modal" tabindex="-1" role="dialog" aria-labelledby="post-new-keep-modal-label">
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
        </div>

</template>

<script>
    export default {
        name: 'Newkeep',
        data() {
            return {
                newKeep: {
                    userId: '',
                    name: '',
                    description: '',
                    imageURL: ''
                }

            }
        },

        methods: {
            submitNewKeep() {
                this.newKeep.userId = this.user.id
                this.$store.dispatch('submitNewKeep', this.newKeep)
            }

        },
        computed: {
            user() {
                return this.$store.state.user
            }

        },
        components: {

        }
    }

</script>

<style>
</style>