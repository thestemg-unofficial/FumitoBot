# from: https://github.com/WhiteBlackGoose/dotfiles/blob/3f7d1b508f75ea87b8f36f3e2be0e2db1f4241c1/envs/dotnet-tool.nix
{
  pkgs,
  stdenv,
}: {
  combineTools = dotnet: list: let
    drv = {
      bin-name,
      nuget-name,
      dll-name,
      version,
      arch,
      sha256,
    }: let
      d = pkgs.fetchzip {
        url = "https://www.nuget.org/api/v2/package/${nuget-name}/${version}";
        sha256 = sha256;
        extension = "zip";
        stripRoot = false;
      };
    in
      pkgs.writeScript "${bin-name}-fake"
      "DOTNET_ROOT=${dotnet} ${dotnet}/dotnet ${d}/tools/${arch}/${dll-name}.dll";
  in
    pkgs.runCommand "tools" {} (''
        mkdir -p $out/bin
      ''
      + (
        builtins.concatStringsSep "\n"
        (
          builtins.map
          (pkg: ''ln -s ${drv pkg} $out/bin/${pkg.bin-name}'')
          list
        )
      ));

  tools = {
    fsautocomplete = rec {
      bin-name = "fsautocomplete";
      nuget-name = bin-name;
      dll-name = bin-name;
      version = "0.59.6";
      arch = "net7.0/any";
      sha256 = "sha256-1yZkDpX9HJ6wPKlpe3RseU6lt0tGQmscal/QeigRUsM=";
    };
  };
}
