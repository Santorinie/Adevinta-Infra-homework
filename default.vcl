# VARNISH CONFIG FILE #
vcl 4.1;

backend backendv1 {
    .host = "host.docker.internal";
    .port = "5000";
}

backend backendv2 {
    .host = "host.docker.internal";
    .port = "5001";
}

sub vcl_recv {
    if(req.url ~ "v2"){
        set req.backend_hint = backendv2;
    }
    else{
        set req.backend_hint = backendv1;
    }
}