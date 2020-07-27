# Pods exploration

## Creation and inspection ##

1. Create the namespace `lab2`.
2. In the namespace `lab2` create a new Pod named `webserver` with the image `nginx:2.3.11`. Expose the port 80.
3. There is an error. Identify the issue with creating the container. Write down the root cause of issue in a file named `web-error.log`.
4. Change the image of the Pod to `nginx:1.15.12`.
5. List the Pod and ensure that the container is running.
6. Log into the container and run the `ls` command. Write down the output. Log out of the container.
7. Retrieve the IP address of the Pod `webserver`.
8. Run a temporary Pod using the image `busybox`, shell into it and run a `wget` command against the `nginx` Pod using port 80.
9. Render the logs of Pod `webserver`.
10. Delete the Pod and the namespace.

## Solution ##

<details>
  <summary>Click to expand</summary>

- Run the `kubectl create` command to create objects in kubernetes

```
master $ kubectl create namespace lab2
namespace/lab2 created
```

- Use the command `kubectl run` with the correct arguments to create a pod
```
master $ kubectl run webserver --image=nginx:2.3.11 --port=80 -n lab2
pod/webserver created
```

- When listing the pods with the command `kubectl get pods -n lab2` there should be an error. Use the Describe command to review the error.
```
master $ kubectl get pods -n lab2
NAME        READY   STATUS         RESTARTS   AGE
webserver   0/1     ErrImagePull   0          102s
master $ kubectl describe pod webserver -n lab2
Name:         webserver
Namespace:    lab2
Priority:     0
Node:         node01/172.17.0.10
Start Time:   Mon, 27 Jul 2020 18:02:32 +0000
Labels:       run=webserver
Annotations:  <none>
Status:       Pending
IP:           10.244.1.3
IPs:
  IP:  10.244.1.3
Containers:
  webserver:
    Container ID:
    Image:          nginx:2.3.11
    Image ID:
    Port:           80/TCP
    Host Port:      0/TCP
    State:          Waiting
      Reason:       ErrImagePull
    Ready:          False
    Restart Count:  0
    Environment:    <none>
    Mounts:
      /var/run/secrets/kubernetes.io/serviceaccount from default-token-xj76w(ro)
Conditions:
  Type              Status
  Initialized       True
  Ready             False
  ContainersReady   False
  PodScheduled      True
Volumes:
  default-token-xj76w:
    Type:        Secret (a volume populated by a Secret)
    SecretName:  default-token-xj76w
    Optional:    false
QoS Class:       BestEffort
Node-Selectors:  <none>
Tolerations:     node.kubernetes.io/not-ready:NoExecute for 300s
                 node.kubernetes.io/unreachable:NoExecute for 300s
Events:
  Type     Reason     Age                 From               Message
  ----     ------     ----                ----               -------
  Normal   Scheduled  105s                default-scheduler  Successfully assigned lab2/webserver to node01
  Normal   Pulling    18s (x4 over 103s)  kubelet, node01    Pulling image "nginx:2.3.11"
  Warning  Failed     17s (x4 over 102s)  kubelet, node01    Failed to pull image "nginx:2.3.11": rpc error: code = Unknown desc = Error response from daemon: manifest for nginx:2.3.11 not found: manifest unknown: manifest unknown
  Warning  Failed     17s (x4 over 102s)  kubelet, node01    Error: ErrImagePull
  Normal   BackOff    4s (x5 over 102s)   kubelet, node01    Back-off pulling image "nginx:2.3.11"
  Warning  Failed     4s (x5 over 102s)   kubelet, node01    Error: ImagePullBackOff
```

- Use `kubectl edit pod webserver -n lab2` to modify the image in the spec
```
spec:
  containers:
  - image: nginx:2.3.11
    imagePullPolicy: IfNotPresent
    name: webserver
    ports:

```
```
master $ kubectl edit pod webserver -n lab2
pod/webserver edited
master $ k get pods -n lab2
NAME        READY   STATUS    RESTARTS   AGE
webserver   1/1     Running   0          8m54s
```
- To "log" into a pod like you log into a server use the `kubectl exec -it` command

```
master $ kubectl exec -it webserver -n lab2 sh
kubectl exec [POD] [COMMAND] is DEPRECATED and will be removed in a future version. Use kubectl kubectl exec [POD] -- [COMMAND] instead.
# ls
bin   dev  home  lib64  mnt  proc  run   srv  tmp  var
boot  etc  lib   media  opt  root  sbin  sys  usr
#

```
- Run a pod with the image busybox and wget `wget` to the Pod Ip.

```
master $ kubectl exec -it webserver -n lab2 sh
kubectl exec [POD] [COMMAND] is DEPRECATED and will be removed in a future version. Use kubectl kubectl exec [POD] -- [COMMAND] instead.
# ls
bin   dev  home  lib64  mnt  proc  run   srv  tmp  var
boot  etc  lib   media  opt  root  sbin  sys  usr
#
```
- Use the `kubectl logs` command to render logs from a Pod.

```
master $ kubectl logs webserver -n lab2
10.244.1.6 - - [27/Jul/2020:18:16:11 +0000] "GET / HTTP/1.1" 200 612 "-" "Wget" "-"
```
- Use `kubectl delete` to delete objects in Kubernetes. Remember to specify the namespace when deleting objects.

```master $ kubectl delete pod webserver
Error from server (NotFound): pods "webserver" not found
master $ kubectl delete pod webserver -n lab2
pod "webserver" deleted
master $ kubectl delete namespace lab2
namespace "lab2" deleted
```

</details>
