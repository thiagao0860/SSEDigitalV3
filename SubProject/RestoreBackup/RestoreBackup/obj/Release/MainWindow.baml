   M S B A M L   `   `   `  ���� H  DRestoreBackup, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RestoreBackupRestoreBackup      RestoreBackup.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:RestoreBackup     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  ���	#FF050034  � Title$  Restaurar Dados��$��265.521��$��663.604�� � 
ResizeMode$ NoResize=�.��� $��0,20,0,0q� � ColumnDefinitions �� $	��14* ��� $	��47* � � RowDefinitions �� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* �.+��� $��	Usuário:��$��Center=�$��Center=�$��0��$��0��$��25��
��������� -    ��Name$ userTextBox��$��1��$��20��$
��20,0q� �� TextWrapping$
 Wrap=�$��Center=�$��0���� $��Senha:��$��Center=�$��Center=�$��1��$��0��$��25��
��������� -   $ senhaTextBox��$��1��$��20��$
��20,0q�$
 Wrap=�$��Center=�$��1���� $��Caminho SystemLog:��$��Center=�$��Center=�$��2��$��25��
�������� $��1��$��2��$��Center=�$��20��$
��20,0q� �� $��1* ��� $��23 �.+��� -   $ pathSystemLogTextBox��$��0��$��C://...��{�.  �� -    ��Name$ getPathSystemLogButton��$��1��.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ FolderAddOutline=�$��18��$
��auto��$��Center=��� $��Caminho CoreDatabase:��$��Center=�$��Center=�$��3��$��25��
�������� $��1��$��3��$��Center=�$��20��$
��20,0q� �� $��1* ��� $��23 �.+��� -   $ pathCoreDBTextBox��$��0��$��C://...��{�.  �� -   $ getPathCoreDBButton��$��1��.��  $ FolderAddOutline=�$��18��$
��auto��$��Center=��� $��0��$��2��$��4�� �� Orientation$ 
Horizontal=�$��RightToLeft=�$
��10,0q�.+��� -   $ mrestoreButton��$��	Restaurar��$��10,0,0,0q�$��23��$
��10,0q����#FFD700�� -   $ mcancelButton��$��Cancelar��$��10,0,0,0q�$��23��$
��10,0q�