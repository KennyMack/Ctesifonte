# -*- mode: ruby -*-
# vi: set ft=ruby  :

machines = {
  "master"   => {"memory" => "1024", "cpu" => "2", "ip" => "110", "image" => "ubuntu/bionic64"}
  # "node01"   => {"memory" => "1024", "cpu" => "2", "ip" => "111", "image" => "ubuntu/bionic64"},
  # "node02"   => {"memory" => "1024", "cpu" => "2", "ip" => "112", "image" => "centos/7"},
  # "registry" => {"memory" => "2048", "cpu" => "2", "ip" => "113", "image" => "ubuntu/bionic64"}
}

Vagrant.configure("2") do |config|

  machines.each do |name, conf|
    config.vm.define "#{name}" do |machine|
      machine.vm.box = "#{conf["image"]}"
      machine.vm.hostname = "#{name}.ctesifonte.com"
      machine.vm.network "private_network", ip: "192.168.16.#{conf["ip"]}"
      machine.vm.provider "virtualbox" do |vb|
        vb.name = "#{name}"
        vb.memory = conf["memory"]
        vb.cpus = conf["cpu"]
        vb.customize ["modifyvm", :id, "--groups", "/Ctesifonte"]
      end
      machine.vm.provision "shell", path: "provision.sh"
      machine.vm.provision "shell", inline: "hostnamectl set-hostname #{name}.ctesifonte.com"
    end
  end
end