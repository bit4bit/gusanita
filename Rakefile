ENV['UID'] = Process.uid.to_s
ENV['GID'] = Process.gid.to_s

$alias_container = {
      'main' => 'main.dev',
      'redis' => 'redis.dev',
}

namespace :prod do
  desc 'build static binary'
  task :build do
    container = $alias_container.fetch('main')
    version = %x[git log -1 --pretty=format:%h].chomp
    
    sh "docker-compose run --rm --no-deps -e VERSION=#{version} #{container} shards build --production --static"
  end
end

namespace :dev do
  task :up do
    sh 'docker-compose up -d --build'
  end

  task :down do
    sh 'docker-compose down -v'
  end

  desc "sh <container>"
  task :sh, :container do |_, args|
    container = $alias_container.fetch(args.container, args.container)

    sh "docker-compose exec #{container} bash"
  end

  desc "restart <container>"
  task :restart, :container do |_, args|
    container = $alias_container.fetch(args.container, args.container)

    sh "docker-compose restart #{container}"
  end

  desc "logs -f <container>"
  task :tail, :container do |_, args|
    container = $alias_container.fetch(args.container, args.container)

    sh "docker-compose logs -f #{container}"
  end
end
