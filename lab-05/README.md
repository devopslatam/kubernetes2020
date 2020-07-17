# Services #

1. Create a new namespace called `prod` . We will create next resources inside this namespace. Remember to use the `-n` flag!
2. Create a new deployment `app1`. Use the `nginx:latest` image. Set the replicas to 4.
3. Create a new service `service1`. Modify the selector so that it uses the Pods running on the deployment `app1` on port 80.
4. Run a new temporary pod with the image `busybox` and run the command `curl service1.prod`. Discuss the results.
5. Update the image of  `app1`. Use the image `nginxdemos/nginx-hello:plain-text ` . Set the replicas to 3 and expose the port 80 of the  container.
6. Create a new service `service2`, but this time use the type `NodePort`, exposing the port 3080, and using the selector to use the deployment `app2`.
7. From the Node01, run the command `curl localhost:3080` multiple times. Discuss the result of the command. 

