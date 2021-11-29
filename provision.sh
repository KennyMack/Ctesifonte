# Garantindo as chaves
#  ssh-keygen -q -t rsa -f key -N ''

KEY_PATH='/vagrant/files'
mkdir -p /root/.ssh
cp $KEY_PATH/key /root/.ssh/id_rsa
cp $KEY_PATH/key.pub /root/.ssh/id_rsa.pub
cp $KEY_PATH/key.pub /root/.ssh/authorized_keys
chmod 400 /root/.ssh/id_rsa*
cat /root/.ssh/id_rsa.pub >> /home/vagrant/.ssh/authorized_keys

# Garantindo os hosts
HOSTS=$(head -n7 /etc/hosts)
echo -e "$HOSTS" > /etc/hosts
echo '192.168.16.110 master.ctesifonte.com' >> /etc/hosts
# echo '192.168.16.111 node01.ctesifonte.com' >> /etc/hosts
# echo '192.168.16.112 node02.ctesifonte.com'>> /etc/hosts
# echo '192.168.16.113 registry.ctesifonte.com' >> /etc/hosts

curl -fsSL https://get.docker.com | bash
systemctl start docker
systemctl enable docker
usermod -aG docker vagrant