   M S B A M L   `   `   `  ����H  DRestoreBackup, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RestoreBackupRestoreBackup  5   	       RestoreBackup.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:RestoreBackup     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   ���	#FF050034  � Title$  Restaurar Dados��5
   	   $��265.521��6!   $��663.604��62    � 
ResizeMode$ NoResize=�6B   .��5      � $��0,20,0,0q�6    � ColumnDefinitions 5   
   �� 5      $	��14* �6   �� 5      $	��47* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� $��	Usuário:��6   $��Center=�6#   $��Center=�6@   $��0��6[   $��0��6h   $��25��6x   
�������6�   �� 5   
   -   5         ��Name$ userTextBox��5      $��1��6'   $��20��67   $
��20,0q�6D    �� TextWrapping$
 Wrap=�6S   $��Center=�6g   $��0��6�   �� 5   
   $��Senha:��6   $��Center=�6!   $��Center=�6>   $��1��6Y   $��0��6f   $��25��6v   
�������6�   �� 5   
   -   5        $ senhaTextBox��5      $��1��6(   $��20��68   $
��20,0q�6E   $
 Wrap=�6T   $��Center=�6h   $��1��6�   �� 5   
   $��Caminho SystemLog:��6   $��Center=�6-   $��Center=�6J   $��2��6e   $��25��6r   
�������6   � 5   
   $��1��6   $��2��6   $��Center=�6-   $��20��6H   $
��20,0q�6T    5      �� 5      $��1* �6#   �� 5      $��23 �6#   .+�5!      �� -   5        $ pathSystemLogTextBox��5!      $��0��64   $��C://...��6D   {�.  6S   �� 5"      -   5         ��Name$ getPathSystemLogButton��5"      $��1��65   .��5#      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ FolderAddOutline=�6*   $��18��6B   $
��auto��6N   $��Center=�6[   5$      5%      �� 5&   
   $��Caminho CoreDatabase:��6   $��Center=�60   $��Center=�6M   $��3��6h   $��25��6u   
�������6�   � 5'   
   $��1��6   $��3��6   $��Center=�6-   $��20��6H   $
��20,0q�6T    5(      �� 5)      $��1* �6#   �� 5*      $��23 �6#   .+�5,      �� -   5        $ pathCoreDBTextBox��5,      $��0��61   $��C://...��6A   {�.  6P   �� 5-      -   5        $ getPathCoreDBButton��5-      $��1��62   .��5.        $ FolderAddOutline=�6*   $��18��6B   $
��auto��6N   $��Center=�6[   5/      50      �� 52   
   $��0��6   $��2��6%   $��4��69    �� Orientation$ 
Horizontal=�6F   $��RightToLeft=�6_   $
��10,0q�6{   .+�53      �� -   5        $ mrestoreButton��53      $��	Restaurar��6-   $��10,0,0,0q�6A   $��23��6S   $
��10,0q�6_   ���#FFD7006�   �� 54      -   5        $ mcancelButton��54      $��Cancelar��6,   $��10,0,0,0q�6?   $��23��6Q   $
��10,0q�6]   6l   55      56      57      