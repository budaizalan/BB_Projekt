   M S B A M L   `   `   `  ����E  ABB_Projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:BB_Projekt
BB_Projekt  5   	       BB_Projekt.Ujablak   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:BB_Projekt     5   	     � WindowStyle$
  None=�5   	   $	��600��6   
������  � AllowsTransparency$
 True��6B   $	��500��5	   	    � 
ResizeMode$ NoResize=�6   $��20(�6+    � 	Resources 5
       �� 
TargetType �� Property �� Value��%   '��       '�� J     '�� �     �� 5   
   " ��6   .�5      ��  � ��
 �����6+   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�69   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�69   5      5      .��5      �� ���#1f2041$��5q�6"    �� CornerRadius$ 20��66   ._�5   
   � .+�5      �� .+�5      �� $��10q�6   $	��220��6%   $��40��61   ���#4b3f72$ 20��6R   $	��Top=�6d   ._�5      �� $��Új termék felvétele��6   
�������$��Center=�6M   5      �� 5       �� Orientation$ 
Horizontal=�6   $��0,50,0,0q�66   .+�5      �� $��Év :��6   $	��200��6+   $��Right=�67   �� 5      -   5        	 ��Name$	 	ujEvTxtbx��5      $��75��61   $��50,0,0,0q�6<   ��6N   �� *ujtermekek[0]+
 �� Mode$
 TwoWay=�5      �� 5      $ 
Horizontal=�6   $��0,20,0,0q�66   .+�5       �� $��Hónap :��6   $	��200��6.   $��Right=�6:   �� 5!      -   5         ��Name$ ujHonapCbbx��5!      $	��150��64   $��50,0,0,0q�6@   ��6R   �� *	honapok+ �� SelectedIndex 6r   �� *ujtermekek[1]+$
 TwoWay=�5"      �� 5#      $ 
Horizontal=�6   $��0,20,0,0q�66   .+�5$      �� $��Nap :��6   $	��200��6,   $��Right=�68   �� 5%      -   5        $ 	ujNapCbbx��5%      $��50��62   $��50,0,0,0q�6=    6O   �� *ujtermekek[2]+$
 TwoWay=�5&      �� 5'      $ 
Horizontal=�6   $��0,20,0,0q�66   .+�5(      �� $��Termék neve :��6   $	��200��64   $��Right=�6@   �� 5)      -   5        $	 ujTermekTxtbx��5)      $	��200��65   $��50,0,0,0q�6A   ��6S   �� *ujtermekek[3]+$
 TwoWay=�5*      �� 5+      $ 
Horizontal=�6   $��0,20,0,0q�66   .+�5,      �� $��Termék ára (Ft) :��6   $	��200��68   $��Right=�6D   �� 5-      -   5        $	 	ujArTxtbx��5-      $	��100��61   $��50,0,0,0q�6=   ��6O   �� *ujtermekek[4]+$
 TwoWay=�5.      �� 5/      $ 
Horizontal=�6   $��	0,150,0,0q�66   .+�50      �� -   5         ��Name$ ujFelvetelBtn��50      $��	Felvétel��64   $��5q�6G   $	��100��6S   $��	125,0,0,0q�6_   6r   �� 51      -   5        $ 
ujMegseBtn��51      $��Mégse��61   $��5q�6A   $	��100��6M   $��50,0,0,0q�6Y   6k   52      53      54      55      56      