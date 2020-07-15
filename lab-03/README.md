# Config Maps #

1. Create a new file called `env.txt` it should have the following:
   - DB_URL=mysql:3306
   - DB_USERNAME=app
2. Create a new ConfigMap named `db-env` from that file
3. Create a namespace lab2
4. Create a new Pod named `service1` that uses the environment variables from the ConfigMap and runs the image `nginx`
5. Shell into the Pod an print the environment variables.
6. Create a new ConfigMap with a different method called `db-env2` . Set a value for DB_URL=localhost:3306
7. Verify the values of the configmaps.
8. Create a new Pod named `service2` that uses the new ConfigMap and run the image `nginx`
9. Modify the Pod service2 to user the ConfigMap `db-env2`



# Secrets #

1. Create a namespace called `dev`

2. Create a new secret named`dev-credentials` with a key/value pair `password=chicharron`in the dev namespace

3. Create a confiMap named `dev-user` with a key/value pair `user=chocorramo`

4. Create a Pod named `backend` using `nginx` as the image and use the ConfigMap to expose as an environment variable `USERNAME` and the secret for a env variable called `PASSWORD`. Create a yaml file for reuse.

5. Log into the Pod and check for the environment variables. You can use the `env` command.

6. Create a namespace called `qa`

7. Can you use the same names for configMap and secrets in this namespace?

8. Can you create the Pod with the same yaml definition?

   